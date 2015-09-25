using System;
using System.Collections.Generic;
using System.IO;

namespace Raspored_asistenti_demonstratori
{
    /* Ova klasa čita podatke o asistentima i demonstratorima
     * i sprema ih u objekte Asistent i Demonstrator, a 
     * te objekte u dvije posebne liste objekata. Mi uzimamo 
     * onu listu koja nam treba.
     */
    class DatotekaOsoba : Put
    {
     
        // metoda vraća listu objekata Asistent 
        private LinkedList<Asistent> datotekaasi()
        {
            //ucitavamo podatke iz datoteke
            string[] str = File.ReadAllLines(put + @"\ad.txt");
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();

            // svaki red datoteke ucitavamo u item2
            foreach (var item2 in str)
            {
                // u polje stringova spremamo razdvojene podatke item2 
                string[] item = item2.Split(';');

                // ako je item na mjestu 0 (mjesto gdje se nalazi A ili D oznaka 
                // za asistenta ili demosa) veliko A onda to znaci da je asistent
                // te instanciramo novi objekt klase Asistent i šaljemo atribute 
                // koji se nalaze na mjestima 1, 2, 3, 4
                if (item[0].Equals("A"))
                {
                    // 1 - ID asistenta
                    // 2 - username asistenta
                    // 3 - password asistenta
                    // 4 - opterecenje
                    Asistent asi = new Asistent(item[1], item[2], item[3], item[4]);
                    
                    // dodajemo u listu 
                    asistent.AddLast(asi);
                }
            }

            return asistent;
        }

        /* ova funkcija radi sve isto osim na mjestu gdje
         * se provjerava koje je slovo na item[0]
         * te vraca listu demosa 
         */
        private LinkedList<Demonstrator> datotekademos()
        {
            string[] str = File.ReadAllLines(put + @"\ad.txt");
           
            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
   
            foreach (var item2 in str)
            {
                string[] item = item2.Split(';');
                if (item[0].Equals("D"))
                {
                    // na mjestima 1, 2, 3, 4 su iste stvari kao i kod asistenta
                    Demonstrator demos = new Demonstrator(item[1], item[2], item[3], item[4]);
                    demonstrator.AddLast(demos);
                }
            }

            return demonstrator;
        }

        #region ProvjereiVracanja

        /* Funkcija provjerava podatke unesene od strane 
         * korisnika , username i password . Prima dva stringa
         * i vraca bool vrijednost na mjesto pozivanja
         */
        public bool provjeraosoba(string user, string pass)
        {
            // stvaramo liste da bi spremili podatke kad pozovemo
            // jednu od prethodne dvije metode
            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();

            // pozivamo metode i spremamo podatke u liste 
            demonstrator = datotekademos();
            asistent = datotekaasi();

            // provjeravamo da li postoji korisnik sa tim 
            // usernameom i passom kod demosa
            foreach (var item in demonstrator)
            {
                if (item.VratiUser().Equals(user) && item.VratiPass().Equals(pass))
                {
                    return true;
                }
            }

            // provjeravamo da li postoji korisnik sa tim 
            // usernameom i passom kod asistenta
            foreach (var item in asistent)
            {
                if (item.VratiUser().Equals(user) && item.VratiPass().Equals(pass))
                {
                    return true;
                }
            }

            return false;
        }

        public int provjeraosoba2(string user)
        {
            // stvaramo liste da bi spremili podatke kad pozovemo
            // jednu od prethodne dvije metode
            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();

            // pozivamo metode i spremamo podatke u liste 
            demonstrator = datotekademos();
            asistent = datotekaasi();

            // provjeravamo da li postoji korisnik sa tim 
            // usernameom kod demosa
            foreach (var item in demonstrator)
            {
                if (item.VratiUser().Equals(user))
                {
                    return 1;
                }
            }

            // provjeravamo da li postoji korisnik sa tim 
            // usernameom kod asistenta
            foreach (var item in asistent)
            {
                if (item.VratiUser().Equals(user))
                {
                    return 0;
                }
            }

            return 2;
        }

        public int provjeraosoba3(string user)
        {
            // stvaramo liste da bi spremili podatke kad pozovemo
            // jednu od prethodne dvije metode
            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();

            // pozivamo metode i spremamo podatke u liste 
            demonstrator = datotekademos();
            asistent = datotekaasi();

            // provjeravamo da li postoji korisnik sa tim 
            // usernameom kod demosa
            foreach (var item in demonstrator)
            {
                if (item.VratiUser().Equals(user))
                {
                    return Convert.ToInt32(item.id);
                }
            }

            // provjeravamo da li postoji korisnik sa tim 
            // usernameom kod asistenta
            foreach (var item in asistent)
            {
                if (item.VratiUser().Equals(user))
                {
                    return Convert.ToInt32(item.id);
                }
            }

            return 0;
        }

        /* Funkcija vraca ime i prezime , tj 
         * Password, Username string
         */
        public string VratiIme(string user)
        {
            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();

            demonstrator = datotekademos();
            asistent = datotekaasi();

            foreach (var item in demonstrator)
            {
                if (item.VratiUser().Equals(user))
                {
                    return item.VratiImePrez();
                }
            }

            foreach (var item in asistent)
            {
                if (item.VratiUser().Equals(user))
                {
                    return item.VratiImePrez();
                }
            }

            return "";
        }

        /* Funkcija vraća opterećenje za zadanog usera 
         */
        public double VratiOpt(string user)
        {
            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();

            demonstrator = datotekademos();
            asistent = datotekaasi();

            foreach (var item in demonstrator)
            {
                if (item.VratiUser().Equals(user))
                {
                    return item.VratiOpterecenje();
                }
            }

            foreach (var item in asistent)
            {
                if (item.VratiUser().Equals(user))
                {
                    return item.VratiOpterecenje();
                }
            }

            return 0.0;
        }

        public double VratiOptID(string ID)
        {
            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();
            string user = "";

            string[] polje = File.ReadAllLines(put + @"\ad.txt");
            foreach (var item in polje)
            {
                string[] polje2 = item.Split(';');
                if (ID == polje2[1])
                {
                    user = polje2[2];
                }
            }

            demonstrator = datotekademos();
            asistent = datotekaasi();

            foreach (var item in demonstrator)
            {
                if (item.VratiUser().Equals(user))
                {
                    return item.VratiOpterecenje();
                }
            }

            foreach (var item in asistent)
            {
                if (item.VratiUser().Equals(user))
                {
                    return item.VratiOpterecenje();
                }
            }

            return 0.0;
        }

        /* Funkcija vraća opterećenje ukupno za sve
         * usere
         */
        public double VratiSveOpt()
        {

            LinkedList<Demonstrator> demonstrator = new LinkedList<Demonstrator>();
            LinkedList<Asistent> asistent = new LinkedList<Asistent>();

            demonstrator = datotekademos();
            asistent = datotekaasi();
            double suma = 0;

            foreach (var item in demonstrator)
            {
                    suma += item.VratiOpterecenje();
            }

            foreach (var item in asistent)
            {
                    suma += item.VratiOpterecenje();
            }

            return suma;

        }
        #endregion
    }
}
