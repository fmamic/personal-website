using System;
using System.Collections.Generic;
using System.IO;

namespace Raspored_asistenti_demonstratori
{
    /* Klasa koja ucitva podatke iz datoteke
     * i sprema ih u listu koju onda salje 
     * glavnu formu koja ucitava obaveze i 
     * prikazuje na ekranu
     */
    class DatotekaObaveza : Put
    {
        /* Ova nam funkcija služi za vraćanje obaveza koje nismo prijavili
         * znači u listu pohranjujemo one obaveze koje nisu selektirane
         */
        public LinkedList<string> datotekaVratiObaveze1()
        {
            string[] str;

            // učitavamo podatke iz datoteke u polje stringova
            // ako je path null znači da korisnik nije rucno dodao put do neke
            // datoteke(File-> Open..) nego se automatski cita 
            // ako path nije null samo stavljamo kao argument funkcije
            // read all lines 
            
            str = File.ReadAllLines(put + @"\obaveze.txt");
            
            /* Pravimo listu objekata koja ce sadrzavat 
             * instance klase Obaveze koja sadrzava listu 
             * termnina i svoje atribute 
             */
            LinkedList<Obaveze> ListaObaveze = new LinkedList<Obaveze>();

            // Lista u koju cemo spremati sve podatke o obavezama 
            LinkedList<string> ListaOT = new LinkedList<string>();

            /* U varijablu item ucitavamo svaki redak 
             * polja string , tj. ucitavamo redak po redak datoteke obaveze.txt
             */
            foreach (string item in str)
            {
                // Razdvajamo string po znaku ; i spremamo u polje (pogledati izgleda datoteke obaveze.txt) 
                string[] polje = item.Split(';');
                
                // Stvaramo instancu Obaveze u koju dodajemo sve potrebne atribute , ima ih 3
                int i = 0;
                Obaveze ob = new Obaveze(polje[i].ToString(), polje[i + 1].ToString(), polje[i + 2].ToString());
                
                /* Prva tri atributa smo dodali , pa krecemo od i = 3 
                 * zato sto su ostali atributi za klasu termin 
                 * pogledati kako izgleda obaveze.txt 
                 * (prva tri atributa obaveze, onda slijedi n termina sa po 6 atributa)
                 */
                for (i = 3; i < polje.Length; i++)
                {
                    /* kreiramo instancu ter od klase Termin
                     * i spremamo 6 atributa . Uvecavamo i += 5 da preskocimo 
                     * sve atribute koji su ostali . Ako je i < polje.Length 
                     * tj. ako petlja ide dalje onda to znaci da ima jos 
                     * termina koje je potrebno zapamtit . 
                     */
                    Termin ter = new Termin(polje[i].ToString(), polje[i + 1].ToString(), polje[i + 2].ToString(), polje[i + 3].ToString(), polje[i + 4].ToString(), polje[i + 5].ToString(), polje[i + 6].ToString());
                    
                    // Dodajemo instancu ter(razred Termin) u listu instance ob (razred Obaveze)
                    ob.termin.AddLast(ter);
                    i += 6;
                }

                // Dodajemo instancu ob razreda Obaveze u ListaObaveza koja je lista objekata i onda idemo po drugi red u datoteci
                ListaObaveze.AddLast(ob);
            }

            /* Pravimo listu ListaOT koju 
             * cemo poslati u GlavnaForma radi prikaza 
             * u texboxu . Uzimamo po jedan objekt Obaveze iz liste ListaObaveze
             * i spremamo ga u item, a druga
             * petlja uzima objekt Termin iz liste termina
             */
            foreach (var item in ListaObaveze)
            {
                foreach (var item2 in item.termin)
                {
                    ListaOT.AddLast(item.VratiObaveze() + item2.VratiTermin());
                }
            }

            return ListaOT;
        }

        /* Ova nam funkcija služi za vraćanje obaveza koje smo prijavili već
         * znači u nju pohranjujemo one obaveze koje su selektirane i kliknuta
         * je tipka Prijava. Kod ponovnog pokretanja iz datoteke prijave.txt citamo
         * obaveze i upisujemo ih u polje odjave
         */
        public LinkedList<string> datotekaVratiObaveze2(string user)
        {
            string[] str = File.ReadAllLines(put + @"\prijave.txt");
            LinkedList<string> ob = new LinkedList<string>();

            foreach (string item in str)
            {
                string[] str2 = item.Split(';');

                // ako str2 odgovara usernameu korisnika koje je TRENUTRNO na sustavu onda
                // if prolazi
                if (str2[0] == user)
                {
                    int i = 0;
                    // Dodajemo sve obaveze koje su kraj usera u datoteci 
                    foreach (var item2 in str2)
                    {
                        if (i != 0)
	                    {
                            ob.AddLast(item2); // spremamo u linkedList
	                    }
                        
                        ++i;
                    }
                }
            }
            return ob;
        }

        /* vraca sve prijavljenje obaveze
         */
        public LinkedList<string> VratiSvePrijave()
        {
            string[] str = File.ReadAllLines(put + @"\prijave.txt");
            LinkedList<string> ob = new LinkedList<string>();

            foreach (string item in str)
            {
                ob.AddLast(item);   
            }
            return ob;
        }

        #region Vrati_Provjere
        /* Vraća minuta svih obaveza 
         */
        public int VratiMinute(string user, string path)
        {
            LinkedList<string> Lista = datotekaVratiObaveze1();

            int suma = 0;
            foreach (var item in Lista)
            {
                string[] str = item.Split(' ');
                suma += Convert.ToInt32(str[4]) * (Convert.ToInt32(provjera(str[5])) + Convert.ToInt32(provjera(str[6])) + Convert.ToInt32(provjera(str[7])));
            }

            return suma;

        }

        /* Vraća listu prijavljenih obaveza
         */
        public string VratiPrijavljenje(string user)
        {
            string[] str = File.ReadAllLines(put + @"\prijave.txt");

            foreach (var item in str)
            {
                string[] item2 = item.Split(';');

                if (item2[0] == user)
                {
                    return item;
                }
            }

            return "";
        }

        /* Provjerava da li je string "-" ako je 
         * onda vraca nulu
         */
        private string provjera(string broj)
        {
            if (broj == "-")
            {
                return 0.ToString();
            }
            else
            {
                return broj;
            }
        }
        #endregion
    }
}
