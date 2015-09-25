using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Raspored_asistenti_demonstratori
{
    /* Ova klasa služi za zapisivanje u datoteku u kojoj
     * pamtimo prijavljenje i odjavljenje obaveze . Nakon 
     * sto se program ugasi u datoteci prijave.txt ostaju
     * zapisani podaci
     */
    class DatotekaPrijave : Put
    {
        // Konstruktor koji prima username koji je jedinstven za
        // svakog korisnika . Prima objekt Obaveze koji smo dobili
        // iz lisboxa 1 ili 2 i bool oznaku koja nam govori koju 
        // funkciju treba pokrenuti
        public DatotekaPrijave(string user, Object Obaveze, bool oznaka)
        {
            // citamo sve podatke iz datoteke prijave.txt (izgleda datoteke -> username;obaveza1;obaveza2; .... ;obavezaN) *Pogledati datoteku* 
            string[] str = File.ReadAllLines(put + @"\prijave.txt");
            LinkedList<string> ob = new LinkedList<string>();
            
            // pretvaramno objekt Obaveze u string
            if (Obaveze == null)
            {
                return;
            }
            string obaveze = Obaveze.ToString();

            // pozivamo određenu funkciju
            if (oznaka)
            {
                Prijava(user, str, ob, obaveze, put);
            }
            else
            {
                Odjava(user, str, ob, obaveze, put);
            } 
        }

        /* U funkciju odjava prenose se potrebni podatci
         * prolazi se korz sve podatke koji se spramaju 
         * u linked listu , a za item koji sadrži username koji 
         * je korisnik upisao kada se prijavljivao , njemu pridružimo 
         * obavezu koja je izabrana u listboxu
         */
        private static void Odjava(string user, string[] str, LinkedList<string> ob, string obaveze, string path)
        {
            foreach (var item in str)
            {
                string[] str2 = item.Split(';');

                // definiramo string kraj kojem pridružujemo username (on je na poziciji 0)
                // na taj string kraj cemo nadovezivat sve obaveze koje pripadaju tom useru
                string kraj = str2[0];
                int i = 0;

                // iteriramo kroz str2 i stringu kraj dodajemo obaveze osim one obaveze
                // koja nam je poslana i koju treba odjaviti 
                foreach (var item2 in str2)
                {
                    if (i != 0 && item2 != "" && item2 != obaveze)
                    {
                        kraj += ";" + item2;
                    }
                    ++i;
                }
                kraj += ";";
                ob.AddLast(kraj);  // u listu dodajemo string kraj , jedan node liste je jedan red u datoteci
            }

            // Zapisujemo u datoteku sve iteme iz liste
            // Prvo instanciramo FileStream za kreiranje(brisanje postojece datoteke ako postoji , ako ne postoji stvarnje nove)
            // i stavljamo FileAccess na Write tj. za pisanje
            FileStream aFile = new FileStream(path + @"\prijave.txt", FileMode.Create, FileAccess.Write);
            StreamWriter Sw = new StreamWriter(aFile);

            int broj = 0;
            foreach (var item in ob)
            {
                ++broj;
            }

            // iteriramo po svim node liste i zapisujemo u datoteku
            foreach (var item in ob)
            {
                --broj;
                if (broj != 0)
                {
                    Sw.WriteLine(item);
                }
                else
                {
                    Sw.Write(item);
                }
            }
            
            Sw.Close(); // zatvaramo stream 
            aFile.Close();
        }

        /* ova funkcija radi približno isto kao i funkcija odjava 
         * osim što obavezu primljenu od strane listboxa
         * DODAJE pored usera koji nam je poslao LoginForma 
         */
        private static void Prijava(string user, string[] str, LinkedList<string> ob, string obaveze, string path)
        {
            foreach (var item in str)
            {
                string[] str2 = item.Split(';');
                string kraj = str2[0];
                int i = 0;

                // Ovdje je jedina razlika , kada prepozna da se radi o useru koji trenutrno 
                // logiran u sustav, on kraj njega dodaje obavezu, znači
                // zaljepi string obaveza za string kraj koji se onda dodaje u listu 
                if (str2[0] == user)
                {
                    kraj += ";" + obaveze;
                }

                foreach (var item2 in str2)
                {
                    if (i != 0 && item2 != "")
                    {
                        kraj += ";" + item2;
                    }
                    ++i;
                }
                kraj += ";";
                ob.AddLast(kraj);
            }

            // identično kao kod funkcije Odjava
            FileStream aFile = new FileStream(path + @"\prijave.txt", FileMode.Create, FileAccess.Write);
            StreamWriter Sw = new StreamWriter(aFile);

            int broj = 0;
            foreach (var item in ob)
            {
                ++broj;
            }

            foreach (var item in ob)
            {
                --broj;
                if (broj != 0)
                {
                    Sw.WriteLine(item);
                }
                else
                {
                    Sw.Write(item);
                }
            }
            Sw.Close();
            aFile.Close();
        }
    }
}
