using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Raspored_asistenti_demonstratori
{
    /* Klasa koja sadrži funkciju sa kojom 
     * auto rasporedimo obaveze nakon sto im 
     * rok istekne
     */
    class AutoRaspored : Put
    {
        // nasljeđuje klasu Put da bi znali put datoteka koje koristimo
        private DateTime date = new DateTime();
        private DatotekaObaveza dat = new DatotekaObaveza();
        private DatotekaOsoba osoba = new DatotekaOsoba();
        private RegulatorMinuta reg = new RegulatorMinuta(null);

        private string user;

        // konstruktor koji dodaje vrijednost useru
        public AutoRaspored(string User)
        {
            user = User;
        }

        /* Funkcija koja provjerava rok da li je istekao 
         * ako je stavlja ga u listu i vraca linked list stringova
         */
        public LinkedList<string> ProvjeraRoka()
        {
            LinkedList<string> Lista = new LinkedList<string>();
            LinkedList<string> List = new LinkedList<string>();
            
            // U Lista se spremaju sve obaveze koje se nalaze u obaveze.txt
            Lista = dat.datotekaVratiObaveze1();

            // Za svaku obavezu u listi uzimamo vrijeme
            foreach (var item in Lista)
            {
                string[] str = item.Split(' ');

                string datum = str[2];
                date = DateTime.ParseExact(datum, "dd.MM.yyyy.-HH:mm", null);

                // ako je vrijeme obaveze minus vrijeme sada manje od nula
                if ((date - DateTime.Now).Minutes < 0)
                {
                    // dodaj u listu
                    List.AddLast(item);
                }
            }

            return List;

        }

  
        /* Funkcija za automatsko raspoređivanje 
         * asistenata i demonstratora nakon isteka roka
         * obaveze .
         */
        public void Automatsko()
        {
            // otvaramo datoteku prijave.txt iz koje citamo prijavljene obaveze
            // za svakog korisnika
            string[] polje = File.ReadAllLines(put + @"\prijave.txt");
            int[,] osobe = new int[100,100]; // definiramo polje osobe za svakog korisnika
            int[,] ob = new int[100, 100]; // definiramo polje ob za svaku obavezu
            int m = 0;

            // u listu stavljamo sve obaveze kojima je istekao rok
            LinkedList<string> Lista = ProvjeraRoka();
            
            // ako je lista prazna odmah završavamo sa ovom funkcijom
            // zato sto nema šta dodjelit 
            if (Lista.Count > 0)
            {
                foreach (var item in polje)
                {
                    string[] item2 = item.Split(';');
                    int n = 1;
                    
                    // u polje dodjaemo ID korisnika na mjesto 0
                    // i koliko jos ima minuta na mjesto 1
                    osobe[m, 0] = Convert.ToInt32(PromjeniID2(item2[0]));
                    osobe[m, 1] = reg.IDMinute(item2[0]);

                    // Za svaki item u datoteci prijave.txt (User;prijavljenaObaveza;prijavljenaObaveza;....)
                    // uzimamo prijavljenu obavezu i dodajemo osobi njen id i id termina
                    foreach (var item3 in item2)
                    {
                        // preskacemo User , zato sto vec imamo UserID na prvom mjestu
                        // u polju obaveze
                        if (n > 1)
                        {
                            string[] item4 = item3.Split(' ');
                            int k = 0, p = 0;
                            foreach (var str in item4)
                            {
                                if (str != "")
                                {
                                    // ako je k == 1 onda konvertiramo ID obaveze u int i 
                                    // spremamo 
                                    if (k == 1)
                                    {
                                        osobe[m, n] = Convert.ToInt32(item4[p]);
                                        ++n;
                                    }

                                    // ako je k == 3 onda konvertiramo ID termina u int
                                    // i brejkamo jer nam vise ne treba nista
                                    if (k == 3)
                                    {
                                        osobe[m, n] = Convert.ToInt32(item4[p]);
                                        break;
                                    }
                                    ++k;
                                }
                                ++p;
                            }
                        }
                        ++n;
                    }
                    ++m;
                }


                int f = 0;

                // Za svaki item u Lista dodajemo u polje ob obaveze u toj listi
                foreach (var item in Lista)
                {
                    string[] item2 = item.Split(' ');

                    // Spremamo prvo IDobaveze 
                    ob[f, 0] = Convert.ToInt32(item2[1]);
                    ob[f, 1] = Convert.ToInt32(item2[3]); // ID termina
                    ob[f, 2] = Convert.ToInt32(item2[4]); // trajanje

                    // Ako je "-" stavljamo -1 tj. ako nema asistenata
                    if (item2[5] == "-")
                    {
                        ob[f, 3] = -1;
                    }
                    else
                    {
                        ob[f, 3] = Convert.ToInt32(item2[5]);
                    }

                    // Ovo je provjera i spremanje za demonstratore
                    if (item2[6] == "-")
                    {
                        ob[f, 4] = -1;
                    }
                    else
                    {
                        ob[f, 4] = Convert.ToInt32(item2[6]);
                    }

                    // Ovo je provjera i spremanje za oba i demos i asistent
                    if (item2[7] == "-")
                    {
                        ob[f, 5] = -1;
                    }
                    else
                    {
                        ob[f, 5] = Convert.ToInt32(item2[7]);
                    }

                    string[] item5 = item2[8].Split(':');

                    if (item5[0] == "-")
                    {
                        ob[f, 7] = -1;
                        ob[f, 8] = -1;
                    }
                    else
                    {
                        ob[f, 7] = Convert.ToInt32(item5[0]);
                        ob[f, 8] = Convert.ToInt32(item5[1]);
                    }

                    string[] item6 = item2[9].Split(':');

                    if (item6[0] == "-")
                    {
                        ob[f, 9] = -1;
                        ob[f, 10] = -1;
                    }
                    else
                    {
                        ob[f, 9] = Convert.ToInt32(item6[0]);
                        ob[f, 10] = Convert.ToInt32(item6[1]);
                    }

                    // racunamo i spremamo ukupan broj minuta za obavezu
                    ob[f, 6] = ob[f, 2] * (provjera(ob[f, 3]) + provjera(ob[f, 4]) + provjera(ob[f, 5]));

                    ++f;
                }

                int i = 0;

                /* u ovom dijelu racunamo i oduzimamo vrijednosti minuta obaveza
                 * tako da provjeravamo koje su obaveze vec prijavljene 
                 * od strane osobe
                 */
                while (osobe[i, 0] != 0)
                {
                    int j = 2;
                    while (osobe[i, j] != 0)
                    {
                        int k = 0;
                        while (ob[k, 0] != 0)
                        {
                            // Ako se poklapaju ID obaveze i ID termina u oba polja
                            if (osobe[i, j] == ob[k, 0] && osobe[i, j + 1] == ob[k, 1])
                            {
                                // oduzimamo od ukupno minuta obaveza
                                // trajanje obaveze
                                ob[k, 6] -= ob[k, 2];

                                int oznaka = provjeraAD(osobe[i, 0]);
                                int prolaz = 0;

                                // ako je demos onda oduzimamo od obaveze demose 
                                // ako je asistent onda asistente
                                switch (oznaka)
                                {
                                    // 0 je za asistente
                                    case 0: 
                                        if (ob[k, 3] > 0)
                                        {
                                            ob[k, 3] -= 1;
                                            if (ob[k, 3] == 0)
                                            {
                                                ob[k, 3] = -1;
                                            }

                                            prolaz = 1;
                                        }
                                        break;

                                    // za demose
                                    case 1:
                                        if (ob[k, 4] > 0)
                                        {
                                            ob[k, 4] -= 1;
                                            if (ob[k, 4] == 0)
                                            {
                                                ob[k, 4] = -1;
                                            }

                                            prolaz = 1;
                                        }
                                        break;
                                }

                                // ako ne prođe ni jedan od asistentat tj. ako u 
                                // obavezi nema mjesta za njih onda umanjujemo zajedničku
                                // brojku
                                if (prolaz == 0)
                                {
                                    if (ob[k, 5] > 0)
                                    {
                                        ob[k, 5] -= 1;
                                        if (ob[k, 5] == 0)
                                        {
                                            ob[k, 5] = -1;
                                        }
                                    }
                                    // ako ni tog nema onda stavljamo demosu ili asistentu -1
                                        // na mjesto te obaveze
                                    else
                                    {
                                        osobe[i, j] = -1;
                                        osobe[i, j + 1] = -1;

                                        osobe[i, 1] += ob[k, 2];
                                        ob[k, 6] += ob[k, 2];
                                    }
                                }

                                // Ako je slucajno nula , znaci da se prijavilo previse aisistenata i demosa
                                if (ob[k, 6] < 0)
                                {
                                    // osobi koja je presla granicu zadnja stavljamo -1 na mjesto te obaveze
                                    osobe[i, j] = -1;
                                    osobe[i, j + 1] = -1;

                                    // vracamo joj minute
                                    osobe[i, 1] += ob[k, 2];
                                    ob[k, 6] += ob[k, 2]; // vracamo minute obavezi
                                }
                            }
                            ++k;
                        }
                        j += 2;
                    }
                    ++i;
                }

                int q = 0;
                while (ob[q, 0] != 0)
                {
                    int v = 0;
                    while (ob[q, 6] != 0)
                    {
                        // pozivamo funkciju max koja nam daje kojoj osobi trebamo
                        // pridružit obavezu
                        int rez = max(osobe, ob[q, 0], ob[q, 1], v, ob);
                        v = 0;

                        // ako je manji od nula brejkamo jer se nije niko našao
                        if (rez < 0)
                        {
                            break;
                        }
                        int oznaka = provjeraAD(osobe[rez, 0]); // provjera da li je asistent ili demos
                        int prolaz = 0;
                        int index = VratiIndex(osobe, rez); // vracamo prvi slobodan index u redku polja

                        switch (oznaka)
                        {
                            // ako je 1 onda je demos
                            case 1:
                                // ako je broj demosa veci od nula onda izvrsavamo
                                if (ob[q, 4] > 0)
                                {
                                    // oduzimamo broj demosa
                                    ob[q, 4] -= 1;
                                    ob[q, 6] -= ob[q, 2];   // oduzimamo ukupno minuta
                                    osobe[rez, index] = ob[q, 0];   // dodajemo osobi ID obaveze
                                    osobe[rez, index + 1] = ob[q, 1];   // dodajemo ID termin
                                    osobe[rez, 1] -= ob[q, 2];  // oduzimamo broj minuta
                                    prolaz = 1;
                                }
                                break;

                            // ako je 0 onda je asistent
                            case 0:
                                // isto kao kod demosa
                                if (ob[q, 3] > 0)
                                {
                                    ob[q, 3] -= 1;
                                    ob[q, 6] -= ob[q, 2];
                                    osobe[rez, index] = ob[q, 0];
                                    osobe[rez, index + 1] = ob[q, 1];
                                    osobe[rez, 1] -= ob[q, 2];
                                    prolaz = 1;
                                }
                                break;

                            default:
                                break;
                        }

                        // ako je prolaz 0 znaci da nema vise mjesta ni za demos ni asistent 
                        // pa provjeravamo broj za oba
                        if (ob[q, 5] > 0 && prolaz == 0)
                        {
                            // isto kao i groe
                            ob[q, 5] -= 1;
                            ob[q, 6] -= ob[q, 2];
                            osobe[rez, index] = ob[q, 0];
                            osobe[rez, index + 1] = ob[q, 1];
                            osobe[rez, 1] -= ob[q, 2];
                            prolaz = 1;
                        }

                        // ako je prolaz jos uvijek nula onda tražimo nekog drugog sa min
                        // brojem minuta ali ako je bio demos sada onda iduce tražimo 
                        // asistenta i obrnuto , zbog toga je ovaj v
                        if (prolaz == 0)
                        {
                            if (oznaka == 1)
                            {
                                v = 1;
                            }
                            else
                            {
                                v = 2;
                            }
                        }
                    }
                    ++q;
                }


                q = 0;

                // Kad smo sve našli onda upisujemo ob polje u datoteku IDobaveze.txt 
                // tako je zadano u zadatku
                while (ob[q, 0] != 0)
                {
                    // otvaramo za append , svaka obaveza ce se priljepit za vec upisanu obavezu
                    FileStream aFile = new FileStream(put + @"\" + ob[q, 0].ToString() + ".txt", FileMode.Append, FileAccess.Write);
                    StreamWriter Sw = new StreamWriter(aFile);

                    /* ovdje izvlačimo za ispis podatke i spremamo ih
                     * u string linija
                     */
                    string linija = ob[q, 0] + ";" + ob[q, 1] + ";";
                    int p = 0;
                    while (osobe[p, 0] != 0)
                    {
                        int k = 2;
                        while (osobe[p, k] != 0)
                        {
                            if (osobe[p, k] == ob[q, 0] && osobe[p, k + 1] == ob[q, 1])
                            {
                                linija += osobe[p, 0] + ";";
                            }
                            k += 2;
                        }
                        ++p;
                    }

                    // mičemo zadnju ";" i zapisujemo u datoteku
                    linija = linija.Remove(linija.Length - 1);
                    Sw.WriteLine(linija);
                    Sw.Close();
                    aFile.Close();

                    ++q;
                }

                LinkedList<string> brisanje = new LinkedList<string>();

                /* ovaj dio služi za brisanje iz obaveze.txt , spremamo u listu 
                 * sve one obaveze koje nisu u listi istekao rok
                 */
                string[] str5 = File.ReadAllLines(put + @"\obaveze.txt");
                int prolaz3 = 0;

                // razdvajamo i tražimo preklapanje ID obaveze
                foreach (var item in str5)
                {
                    string[] item2 = item.Split(';');
                    foreach (var item3 in Lista)
                    {
                        string[] item4 = item3.Split(' ');
                        if (item4[1] == item2[1])
                        {
                            // ako se poklapa staviomo prolaz na 1
                            prolaz3 = 1;
                        }
                    }
                    if (prolaz3 != 1)
                    {
                        // dodajemo item u listu
                        brisanje.AddLast(item);
                    }

                    prolaz3 = 0; // resetiramo prolaz
                }

                // Isto radimo i sa prijavama , moramo maknuti sve prijave
                // Koje su automatski dodjeljene iz prijave.txt
                string[] str6 = File.ReadAllLines(put + @"\prijave.txt");
                LinkedList<string> brisanje2 = new LinkedList<string>();

                foreach (var item in str6)
                {
                    // Ovdje je veci problem makniti iz liste zato sto
                    // imamo i usera i obaveze nisu u optimalnom stanju
                    // sa jednim razmakom 
                    string[] item2 = item.Split(';');
                    int n = 0;
                    string li = item2[0] + ";";
                    foreach (var item3 in item2)
                    {
                        if (n != 0 && item3 != "")
                        {
                            int prolaz4 = 0;
                            foreach (var item8 in Lista)
                            {
                                string[] item9 = item8.Split(' ');

                                string ido = "";

                                int p = 0;
                                string[] item5 = item3.Split(' ');
                                foreach (var item6 in item5)
                                {
                                    if (item6 != "")
                                    {
                                        if (p == 1)
                                        {
                                            // iskopamo id obaveze
                                            ido = item6;
                                            break;
                                        }
                                        ++p;
                                    }
                                }

                                // ako je id obaveze jednak kao i u listi itek roka
                                if (item9[1] == ido)
                                {
                                    prolaz4 = 1;
                                }
                            }

                            // ako je prolaz4 nula to znači da toj obavezi rok nije isteka
                            // pa onda ga dodajemo u string
                            if (prolaz4 == 0)
                            {
                                li += item3 + ";";
                            }
                            prolaz4 = 0; // resetiramo
                        }
                        ++n;
                    }

                    // dodajemo u listu string li
                    brisanje2.AddLast(li);
                }

                // Zapisujemo u obaveze.txt iz one liste
                FileStream aFile2 = new FileStream(put + @"\obaveze.txt", FileMode.Create, FileAccess.Write);
                StreamWriter Sw2 = new StreamWriter(aFile2);

                int broj = 0;
                foreach (var item in brisanje)
                {
                    ++broj;
                }

                foreach (var item in brisanje)
                {
                    --broj;
                    if (broj != 0)
                    {
                        Sw2.WriteLine(item);
                    }
                    else
                    {
                        Sw2.Write(item);
                    }
                }

                Sw2.Close();
                aFile2.Close();

                // Zapisujemo u prijave 
                FileStream aFile3 = new FileStream(put + @"\prijave.txt", FileMode.Create, FileAccess.Write);
                StreamWriter Sw3 = new StreamWriter(aFile3);

                broj = 0;
                foreach (var item in brisanje2)
                {
                    ++broj;
                }

                foreach (var item in brisanje2)
                {
                    --broj;
                    if (broj != 0)
                    {
                        Sw3.WriteLine(item);
                    }
                    else
                    {
                        Sw3.Write(item);
                    }
                }

                Sw3.Close();    // zatvaranje obavezno
                aFile3.Close();
            }
        }

        /* U ovom odjeljku su funkcije koje poziva Automatsko vecinom
         * provjere
         */
        #region FunkcijeProvjere
        
        // provjerava je li broj pozitivan
        private int provjera(int broj)
        {
            if (broj < 0)
            {
                return 0;
            }
            else
            {
                return broj;
            }
        }

        // ako je nula vraca -1 inace broj
        private int provjera2(int broj)
        {
            if (broj == 0)
            {
                return -1;
            }
            else
            {
                return broj;
            }
        }

        // Vraca ID trenutnog usera
        private string PromjeniID()
        {
            string[] str = File.ReadAllLines(put + @"\ad.txt");
            foreach (var item in str)
            {
                string[] item2 = item.Split(';');
                if (item2[2] == user)
                {
                    return item2[1];
                }
            }
            return "";
        }

        // vraca ID bilo kojeg usera poslanog parametrom
        public string PromjeniID2(string usr)
        {
            string[] str = File.ReadAllLines(put + @"\ad.txt");
            foreach (var item in str)
            {
                string[] item2 = item.Split(';');
                if (item2[2] == usr)
                {
                    return item2[1];
                }
            }
            return "";
        }

        // Najvažnija funkcija ovdje koja određuje asistenta ili demosa
        // koji ima najvise minuta slobodnih , a ne smije imati vec
        // prijavljeni termin , i jos int v nam služi da ne smije biti
        // asistent ili da ne smije biti demos jedno od toga 
        public int max(int[,] polje, int obaveza, int termin, int v, int[,] polje2)
        {
            int i = 0;
            int max = 0;
            int rez = -1; // postavljamo -1 rez 

            while (polje[i, 0] != 0)
            {
                int prolaz = 0, j = 2, prolaz2 = 1, prolaz3 = 0;
                int oznaka;
                while (polje[i, j] != 0)
                {
                    prolaz3 = vrijeme(polje[i,j], polje[i,j+1], obaveza, termin, polje2);
                    // provjeravamo da li ima vec obaveza i termin kod osobe
                    if (polje[i,j] == obaveza && polje[i, j+1] == termin)
                    {
                        prolaz = 1;
                    }
                    j += 2;
                }

                // ako je v 1 onda znaci da moramo uzeti asistenta 
                if (v == 1)
                {
                    oznaka = provjeraAD(polje[i, 0]);
                    if (oznaka == 0)
                    {
                        prolaz2 = 1;
                    }
                    else
                    {
                        prolaz2 = 0;
                    }
                }

                // ako je v 2 onda moramo uzeti demosa
                if (v == 2)
                {
                    oznaka = provjeraAD(polje[i, 0]);
                    if (oznaka == 1)
                    {
                        prolaz2 = 1;
                    }
                    else
                    {
                        prolaz2 = 0;
                    }
                }

                // provjeravamo sve uvjete i dodjeljujemo max
                if (polje[i, 1] > max && prolaz != 1 && prolaz2 == 1 && prolaz3 != 1)
                {
                    max = polje[i, 1];
                    rez = i;
                }
                ++i;
            }

            return rez;
        }

        public int vrijeme(int obaveza1, int termin1, int obaveza2, int termin2, int[,] polje)
        {
            int i = 0, h1 = 0, h2 = 0, h3 = 0, h4 = 0, m1 = 0, m2 = 0, m3 = 0, m4 = 0, t1 = 0, t2 = 0;

            while (polje[i, 0] != 0)
            {
                if (polje[i, 0] == obaveza1 && polje[i, 1] == termin1)
                {
                    h1 = polje[i, 7];
                    m1 = polje[i, 8];
                    h2 = polje[i, 9];
                    m2 = polje[i, 10];
                    t1 = h1 - h2;
                    t2 = m1 - m2;
                    ++i;
                    continue;
                }

                if (polje[i, 0] == obaveza2 && polje[i, 1] == termin2)
                {
                    h3 = polje[i, 7];
                    m3 = polje[i, 8];
                    h4 = polje[i, 9];
                    m4 = polje[i, 10];
                }
                ++i;
            }

            if (Math.Abs(h1- h3) <= Math.Abs(t1))
            {
                if (Math.Abs(m1- m3) <= Math.Abs(t2))
                {
                    return 1;
                }
            }

            return 0;

        }

        /* Funkcija koja provjerava da li je osoba asistent ili demos
         */
        public int provjeraAD(int broj)
        {
            string[] str = File.ReadAllLines(put + @"\ad.txt");

            foreach (var item in str)
            {
                string[] item2 = item.Split(';');
                if (item2[1] == broj.ToString())
                {
                    // Slovo A ili D je na pocetku stringa na mjesu 0
                    if (item2[0].Equals("A"))
                    {
                        return 0;
                    }
                    if (item2[0].Equals("D"))
                    {
                        return 1;
                    }
                }
            }
            return 2;
        }

        /* Vraca index prvog praznog polja u redku
         */
        public int VratiIndex(int[,] polje, int redak)
        {
            int j = 0;
            for (int i = 0; polje[i, 0] != 0 && i != redak +1 ; i++)
            {
                for (j = 2; polje[i, j] != 0; j++)
                {
                }
            }

            // vraćamo broj stupca koji je prazan
            return j;
        }
        #endregion
    }
}
