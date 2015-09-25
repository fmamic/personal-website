using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Raspored_asistenti_demonstratori
{
    /* Klasa Sustav sadrži main funkciju koja pokrece
     * login formu. Kada login forma da znak da je korisnik
     * ispravan onda pokrece glavnu formu
     */
    class Sustav
    {
        // Ovaj STATthread znači da koristimo samo jednu dretvu 
        [STAThreadAttribute]
        public static void Main()
        {
            Application.EnableVisualStyles();
            // Instanciramo prvo klasu login
            Login Log = new Login();

            // Ako je prijava uspjesna 
            if (Log.ShowDialog() == DialogResult.OK)
            {
                // Onda instanciramo klasu GlavnaForma kojoj šaljemo
                // username koji je korisnik upisao 
                GlavnaForma GL = new GlavnaForma(Log.User());

                Log.Hide(); // Kada je dialogresult OK login prozor se miče
                Application.Run(GL); // pokrece se aplikacija sa instancom razreda GlavnaForma
            }
        }
    }
}
