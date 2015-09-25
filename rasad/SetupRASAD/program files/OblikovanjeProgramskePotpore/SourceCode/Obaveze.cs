using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raspored_asistenti_demonstratori
{
    class Obaveze
    {
        // atributi klase Obaveze
        public string imeObaveze;
        public string IdObaveze;
        public string rokObaveze;

        // lista koja sadrži objekte Termin 
        public LinkedList<Termin> termin = new LinkedList<Termin>();

       //Funkcija koja vraca spojene atribute (treba nam za prikaz u texboxu)
        public string VratiObaveze()
        {
            return imeObaveze + " " + IdObaveze + " " + rokObaveze;
        }

        // Konstruktor koji pridruzuje vrijednost atributima
        public Obaveze(string imeO, string IdO, string rokO)
        {
            imeObaveze = imeO;
            IdObaveze = IdO;
            rokObaveze = rokO;
        }
    }

    class Termin
    {
        // atributi klase Termin
        public string IdTermina;
        public string Trajanje;
        public string brojA;
        public string brojD;
        public string brojAD;
        public string VrijemP;
        public string VrijemeK;

        //Funkcija koja vraca spojene atribute (treba nam za prikaz u texboxu)
        public string VratiTermin()
        {
            return " " + IdTermina + " " + Trajanje + " " + brojA + " " + brojD + " " + brojAD + " " + VrijemP + " " + VrijemeK;
        }

        // Konstruktor koji pridruzuje vrijednost atributima
        public Termin(string ID, string trajanje, string Abroj, string Dbroj, string ADbroj, string Pvrrijeme, string Kvrijeme)
        {
            IdTermina = ID;
            Trajanje = trajanje;
            brojA = Abroj;
            brojD = Dbroj;
            brojAD = ADbroj;
            VrijemeK = Kvrijeme;
            VrijemP = Pvrrijeme;
        }
    }
}
