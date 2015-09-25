using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raspored_asistenti_demonstratori
{
    /* klasa demonstrator nam služi da bi zapamtili 
     * podatke o demostratoru i spremili u 
     * odgovarajuce atribute
     */

    class Demonstrator : Osoba  // klasa demonstrator nasljeđuje atribute klase Osoba 
    {

        // Konstruktor koji pridružuje vrijednosti atributima 
        public Demonstrator(string id, string user, string pass, string opterecenje)
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
