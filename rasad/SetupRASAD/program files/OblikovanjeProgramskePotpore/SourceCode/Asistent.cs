using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raspored_asistenti_demonstratori
{
    /* klasa asistent nam služi da bi zapamtili 
     * podatke o asistentu i spremili u 
     * odgovarajuce atribute
     */
    class Asistent : Osoba // nasljeđuje atribute klase Osoba
    {

        // Konstruktor pridružuje vrijednosti atributima , znamo da 
        // nece biti ni manje ni vise poslanih vrijednosti pa nam je dosta
        // samo ovaj jedan konstruktor 
        public Asistent(string id, string user, string pass, string opterecenje)
        {
            username = user;
            password = pass;
            this.id = id;

            double duljina = opterecenje.Length - opterecenje.IndexOf('.') - 1;
            double num1 = Convert.ToDouble(opterecenje.Substring(opterecenje.IndexOf('.') + 1));
            double num2 = Convert.ToDouble(opterecenje.Substring(0, opterecenje.IndexOf('.')));

            num3 = num2 + num1 * Math.Pow(10, -(duljina)); 
        }
    }
}
