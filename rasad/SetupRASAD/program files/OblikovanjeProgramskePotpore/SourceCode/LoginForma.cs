using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Raspored_asistenti_demonstratori
{
    /* Ova klasa nasljeđuje metode i 
     * atribute klase Form . Klasa Form
     * je vec napisana klasa za ostvarivanje
     * grafickog sucelja. Korisnik upisuje 
     * user i pass , provjerava se ispravnost
     * ako je ispravno onda se postavlja 
     * DialogResult na OK i Main funkcija
     * zatvara login formu i pokrece glavnu 
     */

    public class Login : Form
    {
        // Instanciramo sve klase koje su 
        // nam potrebne 
        private Button BtnOK = new Button();
        private Button BtnCancel = new Button();
        private Button BtnReg = new Button();

        private TextBox Tex1 = new TextBox();
        private TextBox Tex2 = new TextBox();

        private Label Lab1 = new Label();
        private Label Lab2 = new Label();
        private Label Lab3 = new Label();

        public string path;
        private DatotekaOsoba dat;

        protected string user;
       
        // Konstruktor koji se prvi izvodi nakon instanciranja 
        // klase . Tu definiramo početni izgled našeg sučelja
        // dodajemo slike, poziciju gumbova itd. 
        public Login()
        {
            path = Application.StartupPath;
            dat = new DatotekaOsoba();

            Color MyColor = Color.FromArgb(0, Color.Green); // instacirali smo klasu Color i postavili na prozirno da bi stavili kao background za Labelu 1 i 2 
            
            // u string exepath1 i 2 stavljamo poziciju nase slike .
            // Slika mora biti u istom folderu kao i sama aplikacija. 
            string exepath1 = Application.StartupPath + @"\login.jpg";
            string exepath2 = Application.StartupPath + @"\diigo.ico";

            // Postavljamo vrijednosti za prozor login
            this.Text = "Prijava na sustav";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Width = 500;
            this.Height = 250;
            this.Location = new Point(Screen.GetWorkingArea(this).Height / 2, Screen.GetWorkingArea(this).Width / 5); // pocetna pozicija prozora
            this.ForeColor = Color.Black; 
            this.BackgroundImage = Image.FromFile(exepath1); // ucitavamo sliku
            this.Icon = new Icon(exepath2);
            this.MaximizeBox = false;   // ne može se povecati (maximizirati)
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            // Postavljamo vrijednosti gumba Cancel
            BtnCancel.Text = "Zatvori";
            BtnCancel.Width = 85;
            BtnCancel.Height = 28;
            BtnCancel.Location = new Point(355, 160);  // pozicija u prozoru , moramo instancirati klasu Point koja prima x,y kordinate
            BtnCancel.Click += new EventHandler(this.BtnCancelm);   // U slucaju pritiska na gumb poziva se metoda koja određuje sto ce se napraviti
            BtnCancel.TabIndex = 3; // Kada pritisnemo Tab tri puta onda dolazimo do ove tipke

            // Postvaljamo vrijednosti gumba OK ostalo slicno kao i kod Cancel samo se poziva druga metoda kod pritiskanja
            BtnOK.Text = "OK";
            BtnOK.Width = 85;
            BtnOK.Height = 28;
            BtnOK.Location = new Point(180, 160);
            BtnOK.Click += new EventHandler(this.BtnOKm);
            BtnOK.TabIndex = 2;

            BtnReg.Text = "Registracija";
            BtnReg.Width = 85;
            BtnReg.Height = 28;
            BtnReg.Location = new Point(267, 160);
            BtnReg.Click += new EventHandler(this.Btnreg);
            BtnReg.TabIndex = 5;

            // Labela koja nam služi za ispisivanje texta
            Lab1.Text = "Korisničko ime";
            Lab1.Width = 130;
            Lab1.Location = new Point(150, 60);
            Lab1.BackColor = MyColor; // pridružili smo prozirnu boju da bi slika iza bila vidljiva
            Lab1.Font = new Font("Ariel", 13, FontStyle.Regular); // instanciramo Font koji se može preopterećivat, u ovom slucaju smo mu poslali tri vrijednosti vrsta, velicina, stil

            // Labela koja nam služi za ispisivanje texta
            Lab2.Text = "Lozinka";
            Lab2.Location = new Point(150, 100);
            Lab2.BackColor = MyColor; 
            Lab2.Font = new Font("Ariel", 13, FontStyle.Regular);

            Lab3.Location = new Point(200, 25);
            Lab3.Width = 150;
            Lab3.BackColor = MyColor;
            Lab3.Font = new Font("Ariel", 11, FontStyle.Regular);

            // postavljamo vrijednosti TexBoxa
            Tex1.Location = new Point(288, 62);
            Tex1.Width = 150;
            Tex1.Font = new Font("Ariel", 11, FontStyle.Regular);
            Tex1.TabIndex = 0;

            // postavljamo vrijednosti TexBoxa
            Tex2.Location = new Point(288, 102);
            Tex2.Width = 150;
            Tex2.PasswordChar = '°';  // Ovo nam služi da bi prikrili slova passworda kada ih upisujemo znakom '°'
            Tex2.Font = new Font("Ariel", 11, FontStyle.Regular);
            Tex2.TabIndex = 1;

            // sve kontrole za koje smo definirali vrijednost , dodajemo na prozor našeg objekta
            this.Controls.Add(Lab3);
            this.Controls.Add(BtnReg);
            this.Controls.Add(Tex2);
            this.Controls.Add(Tex1);
            this.Controls.Add(Lab2);
            this.Controls.Add(Lab1);
            this.Controls.Add(BtnCancel);
            this.Controls.Add(BtnOK);

        }

        /* Kada korisnik pritisne gumb Cancel onda
         * postavimo textove u texboxovima 
         * na prazne stringove
         */
        private void BtnCancelm(Object Sender, EventArgs e)
        {
            Tex1.Text = "";
            Tex2.Text = "";
        }

        /* Kada se pritisne gumb OK onda se poziva ova funkcija 
         * koja provjerava podatke o username i passwordu 
         */
        public void BtnOKm(Object Sender, EventArgs e)
        {
            // Ako je duljina texta upisanog u prvi ili drugi manja od 1 
            // znači da je texbox prazan te se ispisuje poruka
            if (Tex1.TextLength < 1 || Tex2.TextLength < 1)
            {
                Lab3.Text = "Ispunite prazna polja";
                Lab3.Refresh();
            }
            else
            {
                // ako nije prazan pozivamo funkciju instance 
                // razreda DatotekaOsoba, šaljemo joj text a
                // ona provjerava da li ima zapisa u datoteci
                bool prolaz;
                
                // vraca bool vrijednost (true ili false)
                prolaz = dat.provjeraosoba(Tex1.Text, Tex2.Text);
                if (prolaz)
                {
                    // ako je true onda dialogresult ovog objekta se postavlja na OK 
                    // i ispisujemo poruku 
                    this.DialogResult = DialogResult.OK;
                    Lab3.Text = "Unos prihvacen";
                    Lab3.Refresh();
                    user = Tex1.Text;
                }
                else
                {
                    // ako nema takvog zapisa u datoteci ispisujemo pogresan unos
                    Lab3.Text = "Unos pogresan";
                    Lab3.Refresh();
                }
            }
        }

        public void Btnreg(Object Sender, EventArgs e)
        {
           Register reg = new Register();
           reg.Show();
        }

        /* Funkcija vraća vrijednost user korisnika koji se logirao.
         * Moramo ovako napisati funkciju zato sto je user
         * protected pa mu ne možemo izravno pristupiti iz neke
         * druge klase . 
         */
        public string User()
        {
            return user;
        }

        public bool Success()
        {
            return true;
        }
    }
}
