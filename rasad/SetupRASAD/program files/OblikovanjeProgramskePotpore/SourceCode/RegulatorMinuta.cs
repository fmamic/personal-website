using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Raspored_asistenti_demonstratori
{
    class RegulatorMinuta : Put
    {
        // Instanciramo razrede
        private AutoRaspored ar;
        private DatotekaObaveza dat1 = new DatotekaObaveza();
        private DatotekaOsoba dat2 = new DatotekaOsoba();
        private DateTime date = new DateTime();
        private DateTime date2 = new DateTime();

        private string user;

        // konstruktor koji dodaje vrijednost useru
        public RegulatorMinuta(string usr)
        {
            user = usr;
        }

        /* Funkcija koja dobiva kao parametar obavezu 
         * za koju provjerava da li ima konfilikata 
         * sa vec prijavljenim obavezama . Znači uzme vrijeme
         * iz liste prijavljenih i iz ove obaveze i uspoređuje
         * Ako je konflik vraca false inace true
         */
        public bool IstoVrijeme(string obaveza)
        {
            // da skratimo vrcenje zamjenimo puno praznina sa jednom
            obaveza = obaveza.Replace("        ", " ");
            string[] str2 = obaveza.Split(' ');
            int n = 0;
            int trajanje1 = 0, trajanje2 = 0;
            string datum = "", datum2 = "";
            string sat = "", sat2 = "";

            int k = 0;

            // za svaki item u obavezi koju smo razdjelili na
            // praznine brojimo k
            foreach (var item in str2)
            {
                if (item != "")
                {
                    // treba nam na mjestu k == 2 jer je to datum
                    if (k == 2)
                    {
                        datum = item;
                    }
                    // na ovom mjestu je trajanje obaveze
                    if (k == 4)
                    {
                        trajanje1 = Convert.ToInt32(item);
                    }
                    // na ovom mjestu je kada zapocinje obaveza
                    if (k == 8)
                    {
                        // ako je "-" znaci da nema vremenski određen pocetak
                        // pa vracamo true jer se može izvesti kad god hocemo
                        // tj nece biti u konfliktu
                        if (item == "-")
                        {
                            return true;   
                        }
                        sat = item;
                        break;
                    }
                    ++k;
                }
            }

            // Datumu roka pridružimo sat početka obaveze
            datum = datum.Remove(12);
            datum += sat;

            // pretvaramo u oblik za datum
            date = DateTime.ParseExact(datum, "dd.MM.yyyy.-HH:mm", null);

            // citamo iz datoteke 
            string[] str = File.ReadAllLines(put + @"\prijave.txt");

            // za svaku obavezu radimo isto kao i ovoj gore obavezi
            // samo spremamo u razlicite varijable i ako nađemo da se
            // jedna obaveza poklapa odma vracamo false
            foreach (var item in str)
            {
                string[] item2 = item.Split(';');
                if (item2[0] == user)
                {
                    if (item2[1] != "")
                    {
                        n = 0;
                        foreach (var item4 in item2)
                        {
                            if (n != 0)
                            {
                                int f = 0;
                                string item10 = item4.Replace("       ", " ");
                                string[] item5 = item10.Split(' ');

                                foreach (var item6 in item5)
                                {
                                    if (item6 != "")
                                    {
                                        if (f == 2)
                                        {
                                            datum2 = item6;
                                        }
                                        if (f == 4)
                                        {
                                            // moramo string konvertat u int
                                            trajanje2 = Convert.ToInt32(item6);
                                        }
                                        if (f == 8)
                                        {
                                            if (item6 == "-")
                                            {
                                                // ako nademo na ovaj znak onda prekidamo sa istraživanjem 
                                                // ove obaveze i prebacujemo na sljedecu
                                                break;
                                            }
                                            else
                                            {
                                                // radimo isto kao i prije, dodajemo sat na datum2
                                                sat2 = item6;
                                                datum2 = datum2.Remove(12);
                                                datum2 += sat2;

                                                date2 = DateTime.ParseExact(datum2, "dd.MM.yyyy.-HH:mm", null);

                                                //ovaj broj nam govori razliku u minutama
                                                int broj = (date - date2).Minutes;

                                                int broj2 = (date - date2).Hours; // u satima
                                                int broj3 = (date - date2).Days; // u danima

                                                // ako je apsolutno od broja2 vece od nula ili apsolutno od broja3
                                                // vece od 2 onda se ta obaveza ne preklapa pa brejkamo
                                                if (Math.Abs(broj2) > 0 || Math.Abs(broj3) > 2)
                                                {
                                                    break;
                                                }

                                                // ako je broj manji od nula
                                                if (broj < 0)
                                                {
                                                    // provjeravamo da li je trajanje vece od aps broja
                                                    if (trajanje1 > Math.Abs(broj))
                                                    {
                                                        // ako je znaci da se poklapa
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    // ako je broj veci od nula uzimamo trajanje2 i provjeravamo
                                                    if (trajanje2 > Math.Abs(broj))
                                                    {
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                        ++f;
                                    }
                                }
                            }
                            ++n;
                        }
                    }
                }
            }

            return true;

        }

        /* Ova funkcija broji ukupno minuta koliko svaki user
         * ima , ali ne množi sa faktorom opterecenja
         * samo daje ukupno za sve usere , a kasnije se 
         * množi pojedinačno za svakog
         */
        public double BrojacMinuta()
        {
            int minute = dat1.VratiMinute(user, put);
            double opterecenje = dat2.VratiSveOpt(); // vraca ukupno opterecenje

            // zbroj svih minuta kroz opterecenje ukupno
            double rezultat = (minute / opterecenje);

            return rezultat;
        }

        /* Ova funkcija vraca minute za određenog usera , 
         *uzima sve obaveze iz liste prijavljenih obaveza
         *i na temelju toga racuna ukupne preostale minute 
         */
        public int PromijeniMinute()
        {
            DatotekaOsoba dato = new DatotekaOsoba();
            ar = new AutoRaspored(user);

            string id = ar.PromjeniID2(user);
            string red = dat1.VratiPrijavljenje(user); // funkcija koja vraca sve obaveze iz liste prijavljenih
            string[] str = red.Split(';');
            int i = 0, suma = 0, prolaz = 0;

            // ne treba nam prazan string
            if (str[1] != "")
            {
                foreach (var item in str)
                {
                    if (i != 0)
                    {
                        string item2 = item.Replace("       ", " ");
                        string[] polje = item2.Split(' ');
                        int k = 0, p = 0;

                        // Sve dok je p manje od duljine polja uvecacamo p
                        // i kada je k == 4 to nam je broj koji tražimo 
                        while (p < polje.Length)
                        {
                            if (polje[p] != "")
                            {
                                if (k == 4)
                                {
                                    // konvertiramo ga u int i zbrajamo sa sumom
                                    suma += Convert.ToInt32(polje[p]);
                                    break;
                                }
                                ++k;
                            }
                            ++p;
                        }
                    }
                    ++i;
                }
            }

            // sum2 je Ukupno minuta pomnoženo sa opterecenjem usera trenutrnog
            double sum2 = BrojacMinuta() * dato.VratiOpt(user);
            
            //oduzmemo sumu2 i sumu i to je naš traženi broj minuta
            return Convert.ToInt32(sum2) - suma;
        }

        /* Ova funkcija vraća broj minuta s obzirom na
         * ID . Znači ne mora biti trenutni user vec
         * samo posaljemo id bilo kojeg usera 
         */
        public int IDMinute(string ID)
        {
            // sve je vise manje isto osim sto saljemo ID umjesto
            // username kao u prethodnoj funkciji
            DatotekaOsoba dato = new DatotekaOsoba();
            string red = dat1.VratiPrijavljenje(ID);
            string[] str = red.Split(';');
            int i = 0, suma = 0, prolaz = 0;

            if (File.Exists("obrisano.txt"))
            {
                prolaz = 1;
            }

            if (prolaz == 1)
            {
                string[] polje = File.ReadAllLines(put + @"\minute.txt");

                foreach (var item in polje)
                {
                    string[] polje2 = item.Split(';');

                    if (polje2[0] == ID)
                    {
                        return Convert.ToInt32(polje2[1]);
                    }

                }
            }

            if (str[1] != "")
            {
                foreach (var item in str)
                {
                    if (i != 0)
                    {
                        string[] polje = item.Split(' ');
                        int k = 0, p = 0;
                        while (p < polje.Length)
                        {
                            if (polje[p] != "")
                            {
                                if (k == 4)
                                {
                                    suma += Convert.ToInt32(polje[p]);
                                    break;
                                }
                                ++k;
                            }
                            ++p;
                        }
                    }
                    ++i;
                }
            }

            // saljemo ID umjesto user i vracamo opterecenje korinika
            // bilo kojeg
            double sum2 = BrojacMinuta() * dato.VratiOpt(ID);
            return Convert.ToInt32(sum2) - suma;
        }

    }
}
