using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raspored_asistenti_demonstratori
{
    /* klasa Osoba sadrži atribute koje nasljeđuju
     * klasa Demonstrator i klasa Asistent 
     */
    class Osoba
    {
        // username i pass stavljamo protected
        // da bi zastitili privatnost :)
        protected string username;
        protected string password;
        public string id;
        public double num3;

        public string VratiImePrez()
        {
            return password + " " + "," + " " + username;
        }

        public double VratiOpterecenje()
        {
            return num3;
        }

        // metoda kojom vadimo username . Ne možemo ga
        // izravno izvaditi zato sto je protected pa moramo 
        // preko metode 
        public string VratiUser()
        {
            return username;
        }

        // isto kao za username
        public string VratiPass()
        {
            return password;
        }
    }
}
