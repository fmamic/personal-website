using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Raspored_asistenti_demonstratori
{
    /* Ovo je kalasa GlavnaForma koja nam prikazuje glavni
     * prozor i upravlja svim iznimkama koje 
     * korisnik napravi (klik na gumb , refresh ...)
     */
    public class GlavnaForma : Form
    {
        #region stvaranjeObjekata
        // instanciramo sve potrebne klase da bi ostvarili
        // grafičko sučelje glavne forme
        private FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        private OpenFileDialog openfile = new OpenFileDialog();
        private MainMenu Menu1 = new MainMenu();
        private ToolBar Tbar = new ToolBar();
        private Button btn1 = new Button();
        private Button btn2 = new Button();
        private StatusBar StatBar = new StatusBar();
        private ListBox lb1 = new ListBox();
        private ListBox lb2 = new ListBox();
        private Button btn3 = new Button();
        private Label lab1 = new Label();
        private Label lab2 = new Label();
        private Label lab3 = new Label();
        private Label lab4 = new Label();
        private Label lab5 = new Label();
        private Label lab6 = new Label();
        private DatotekaOsoba datO = new DatotekaOsoba();
        private AutoRaspored auto;
        public string exe;

        protected string user;
        private string openFilename;
        #endregion

        // instanciramo klasu DatotekaObaveza koja nam služi za
        // manipuliranje i citanje obaveza i termina
        private DatotekaObaveza dat;

        /* Konstruktor glavne forme koji prima parametar username
         * tj. parametar korisnika koji je trenutrno logiran 
         * na sustav da bi znali kome i gdje zapisivat sto je
         * prijavio , a sto odjavio 
         */
        public GlavnaForma(string User)
        {

            LinkedList<Obaveze> ListaOdjava = new LinkedList<Obaveze>();

            // pokrecemo funkciju auto koja traži obaveze koje su 
            // istekle i raspoređuje ih automatski
            auto = new AutoRaspored(user);
            auto.Automatsko();

            dat = new DatotekaObaveza();
            exe = Application.StartupPath;

            // Dodjeljujemo vrijednost protected stringu user 
            user = User;

            // U stringove spremamo poziciju programa plus ime slike
            string exepath2 = Application.StartupPath + @"\diigo.ico";
            string exepath1 = Application.StartupPath + @"\back.png";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            // Pozivamo funkcija za postavljanje prozora, gumbova, labela, listboxa , menia, statusbara
            Prozor(exepath2);
            Gumbovi();
            Labele();
            ListBox();
            Meni();
            StatusBar();
            DodavanjeKontrola();

        }

        /* U ovom odjeljku smo ostvarili sve funkcije
         * vezane u graficko sucelje koje se pozivaju iz konstruktora
         */
        #region GrafickeFunkcije
        private void StatusBar()
        {
            // Instanciramo dva panela
            StatusBarPanel StatPanel = new StatusBarPanel();
            StatPanel.Text = "Ready"; // Upisujemo Ready u prvi panel
            StatPanel.AutoSize = StatusBarPanelAutoSize.Contents; 
            StatusBarPanel StatPanel2 = new StatusBarPanel();
            StatPanel2.Text = DateTime.Now.ToString();  // upisujemo vrijeme u drugi 
            StatPanel2.AutoSize = StatusBarPanelAutoSize.Spring;
            
            // dodajemo panele u statusbar
            StatBar.Panels.Add(StatPanel);  
            StatBar.Panels.Add(StatPanel2);
            StatPanel2.Alignment = HorizontalAlignment.Right; 
            StatBar.ShowPanels = true;  // postavljamo prikazivanje na true
        }

        private void Prozor(string exepath2)
        {
            // Postavljamo vrijednosti prozora
            this.Width = 900;
            this.Height = 600;
            this.Location = new Point(Screen.GetWorkingArea(this).Height / 3, Screen.GetWorkingArea(this).Width / 10);
            this.Text = "Program RASAD";
            this.BackgroundImage = Image.FromFile(exe + @"\gray.jpg");
            this.Icon = new Icon(exepath2);
        }

        private void Gumbovi()
        {
            // Postavljamo vrijednosti gumba Prijava 
            btn1.Text = "Prijava";
            btn1.Width = 180;
            btn1.Height = 75;
            btn1.Location = new Point(20, 20);
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += new EventHandler(this.btn1_Clicked); // Ako je gumb kliknut onda se poziva metoda koja određuje sljedeće korake

            // Postavljamo vrijednosti gumba Odjava
            btn2.Text = "Odjava";
            btn2.Width = 180;
            btn2.Height = 75;
            btn2.Location = new Point(20, 115);
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += new EventHandler(this.btn2_Clicked);

            // Postavljamo vrijednosti gumba Exit
            btn3.Text = "Zatvori";
            btn3.Width = 180;
            btn3.Height = 45;
            btn3.UseVisualStyleBackColor = true;
            btn3.Location = new Point(20, 470);
            btn3.Click += new EventHandler(this.exit1);
        }

        private void Labele()
        {

            // Postavljamo vrijednosti labele koja se nalazi iznad listboxa 
            lab1.Text = "Obaveza          ID                    Rok           IDtermin   Trajanje  BrojA BrojD BrojAD    VrijemeP   VrijemeK";
            lab1.Width = 600; 
            lab1.BackColor = Color.Transparent;
            lab1.Location = new Point(302, 20);
            lab1.Font = new Font("Arial", 9, FontStyle.Regular);

            lab2.Text = "Opterećenje : ";
            lab2.Width = 200;
            lab2.BackColor = Color.Transparent;
            lab2.Location = new Point(25, 240);
            lab2.Font = new Font("Arial", 13, FontStyle.Regular);

            lab3.Text = "Preostalo minuta : ";
            lab3.Width = 200;
            lab3.BackColor = Color.Transparent;
            lab3.Location = new Point(25, 320);
            lab3.Font = new Font("Arial", 13, FontStyle.Regular);

            lab4.Text = datO.VratiIme(user);
            lab4.Width = 200;
            lab4.BackColor = Color.Transparent;
            lab4.Location = new Point(25, 410);
            lab4.Font = new Font("Arial", 13, FontStyle.Regular);

            lab5.Text = datO.VratiOpt(user).ToString();
            lab5.Width = 200;
            lab5.BackColor = Color.Transparent;
            lab5.Location = new Point(40, 270);
            lab5.Font = new Font("Arial", 13, FontStyle.Regular);

            RegulatorMinuta reg = new RegulatorMinuta(user);

            lab6.Text = reg.PromijeniMinute().ToString();
            lab6.Width = 200;
            lab6.BackColor = Color.Transparent;
            lab6.Location = new Point(40, 350);
            lab6.Font = new Font("Arial", 13, FontStyle.Regular);
        }

        private void ListBox()
        {
            // Postavljamo vrijednosti prvog listboxa
            lb1.Width = 560;
            lb1.Height = 220;
            lb1.Location = new Point(300, 45);
            Textbox_dodavanje_Prijava(dat.datotekaVratiObaveze1(), dat.datotekaVratiObaveze2(user)); // U listbox dodajemo sve obaveze na koje se korisnik može prijaviti 

            // Postavljamo vrijednosti drugog listboxa
            lb2.Width = 560;
            lb2.Height = 230;
            lb2.Location = new Point(300, 265);
            Textbox_dodavanje_Odjava(dat.datotekaVratiObaveze2(user));
        }

        private void DodavanjeKontrola()
        {
            // dodajemo sve kontrole u trenutni objekt
            this.Controls.Add(lab6);
            this.Controls.Add(lab5);
            this.Controls.Add(lab4);
            this.Controls.Add(lab3);
            this.Controls.Add(lab2);
            this.Controls.Add(lab1);
            this.Controls.Add(lb1);
            this.Controls.Add(lb2);
            this.Controls.Add(StatBar);
            this.Controls.Add(btn3);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
        }

        private void Meni()
        {
            // Meniu objekta dodajemo naš instancirani objekt
            this.Menu = Menu1;
            this.MaximizeBox = false;

            // Instanciramo svaki item te ga dodajemo u Menu 
            MenuItem mFile = Menu1.MenuItems.Add("&File");
            MenuItem mOpen = mFile.MenuItems.Add("&Otvori..", new EventHandler(this.OpenFile));
            mOpen.Shortcut = Shortcut.CtrlO;
            mFile.MenuItems.Add("-");
            MenuItem mExit = mFile.MenuItems.Add("Izlaz", new EventHandler(this.exit1)); // Kada korisnik klikne na Exit onda poziva metodu 
            mExit.Shortcut = Shortcut.CtrlQ;

            MenuItem mTools = Menu1.MenuItems.Add("&Alati");
            MenuItem mRef = mTools.MenuItems.Add("Osvježi", new EventHandler(this.ref1)); // Kada korisnik klikne na Refresh onda poziva metodu 
            mTools.MenuItems.Add("-");
            MenuItem mAuto = mTools.MenuItems.Add("Auto Raspored", new EventHandler(this.Autom));
            MenuItem mDodaj = mTools.MenuItems.Add("Dodaj Obaveze", new EventHandler(this.AddO));
            mDodaj.Shortcut = Shortcut.CtrlShiftO;
            mAuto.Shortcut = Shortcut.CtrlA;
            mRef.Shortcut = Shortcut.CtrlR;

            MenuItem mHelp = Menu1.MenuItems.Add("&Pomoć");
            MenuItem mAbout = mHelp.MenuItems.Add("&O Programu", new EventHandler(this.about1)); // Kada korisnik klikne na About onda poziva metodu koja instancira klasu About te ju prikazuje
            mAbout.Shortcut = Shortcut.CtrlH;
        }
        #endregion

        /* Ovdje su funkcije koje pozivamo nekom specifičnom akcijom
         * kao sto su klik na gumb itd. kao i funkcije koje pozivamo
         * kad trebamo preurediti neki string ..
         */
        #region PozivneFunkcije
        /* Funkcija prima listu obaveza i termina , 
         * petlja foreach uzima po jedan dio liste i 
         * dodaje ga u texbox
         */ 
        private void Textbox_dodavanje_Prijava(LinkedList<string> ListaOT, LinkedList<string> ListaPrijava)
        {
            // Pozivamo funkciju da nam napravi string 
            // tj da ga popuni prazninama
            string[] str = NapraviString(ListaOT);

            // Uzima svaki item iz ListaOT i dodaje ga u lisbox1
            foreach (var item in str)
            {
                if (item != null)
                {
                    lb1.Items.Add(item);   
                }
            }
            foreach (var item in ListaPrijava)
            {
                lb1.Items.Remove(item);
            }
        }

        /* Funkcija za otvaranje i dodavanje dodatnih obaveza
         */
        private void OpenFile(Object Sender, EventArgs e)
        {

            MessageBox.Show("Datoteka mora biti propisanog sadržaja i oblika kao npr. obaveze.txt ! Ako je jedan znak pogrešan dolazi do problema pa koristite zadane upute pri pravljenju vlasiste datoteke", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult rezultat = openfile.ShowDialog();
            
            if (rezultat == DialogResult.OK)
            {
                openFilename = openfile.FileName;
                RegulatorMinuta reg = new RegulatorMinuta(user);

                string[] str = File.ReadAllLines(openFilename);
                FileStream aFile = new FileStream(exe + @"\obaveze.txt", FileMode.Append, FileAccess.Write);
                StreamWriter Sw = new StreamWriter(aFile);

                foreach (var item in str)
                {
                    Sw.WriteLine("");  // zapisujemo
                    Sw.Write(item);    
                }
                
                Sw.Close();
                aFile.Close();

                lb1.Items.Clear();
                Textbox_dodavanje_Prijava(dat.datotekaVratiObaveze1(), dat.datotekaVratiObaveze2(user));
                lab6.Text = reg.PromijeniMinute().ToString();

            }
            else if (rezultat == DialogResult.Cancel)
            {
                return;
            }
        }

        /* Funkcija radi slično kao i prethodna
         * samo sto dodaje u drugi Listbox i to 
         * iz liste Odjava
         */
        private void Textbox_dodavanje_Odjava(LinkedList<string> ListaOdjava)
        {
            // Pozivamo funkciju da nam napravi string 
            // tj da ga popuni prazninama
            string[] str = NapraviString(ListaOdjava);

            foreach (var item in str)
            {
                if (item != "" && item != null && !item.StartsWith(" "))
                {
                    lb2.Items.Add(item);
                }
            }
        }

        /* Metoda koje se poziva u trenutku kada 
         * je kliknut gumb Prijava
         */
        private void btn1_Clicked(Object Sender, EventArgs e)
        {
            if (lb1.SelectedItem != null)
            {
                // Instanciramo klase RegulatorMinuta koji nam broji preostale minute
                // za obaveze i usere
                RegulatorMinuta reg = new RegulatorMinuta(user);
                LinkedList<string> listaIstek = new LinkedList<string>();   // Lista koja sadrži obaveze koje su istekle

                // ova vrijednost je postavljena na true , a mjenja se u slučaju nemogućnosti prijavljivanja obaveze
                bool vrijednost = true;

                listaIstek = auto.ProvjeraRoka();  // Pozivamo funkciju u koju spremamo istekle obaveze

                // definiramo vrijednost vrijeme koja nam kaže da li je selektirana obaveza u vremenskom konfliktu 
                // sa nekom drugom obavezom koja je vec prijavljena
                bool vrijeme = reg.IstoVrijeme(lb1.SelectedItem.ToString());

                // Za svaki item u listi isteklih obaveza provjeravamo da li se poklapa sa selektiranom , tj. označenom obavezom
                foreach (var item in listaIstek)
                {
                    string[] item2 = item.Split(' ');

                    // Ako se ID obaveza poklapaju , znači da je rok istekao 
                    if (item2[1].Equals(VratiID(lb1.SelectedItem.ToString())))
                    {
                        // Ispisujemo poruku
                        MessageBox.Show("Za izabranu obavezu je rok istekao - odaberite opciju Auto Obaveze u Alatima", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Pokrecemo funkciju automatsko koja raspoređuje tu obavezu automatski
                        auto.Automatsko();
                        int index1 = lb1.SelectedIndex;
                        lb1.Items.RemoveAt(index1);  // mičemo obavezu iz ponude za prijavu posto smo je dodjelili svima
                        lb1.Refresh();
                        vrijednost = false; // vrijednost je false zato sto se dogodila greska
                        break;
                    }
                }

                int broj = reg.PromijeniMinute();
                if (vrijednost)
                {
                    DatotekaPrijave prijava = new DatotekaPrijave(user, lb1.SelectedItem, true);

                    // u broj stavljamo preostale minute trenutnog usera
                    broj = reg.PromijeniMinute();

                }

                if (broj < 0)
                {
                    // Ako su minute korisnika manje od nula onda je izabrao previse obaveza
                    DatotekaPrijave odjava = new DatotekaPrijave(user, lb1.SelectedItem, false);
                    MessageBox.Show("Izabrali ste previse obaveza", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Ako je izabrana neka obaveza i vrijednost je true onda se provjerava
                    // da li je vrijeme isto kao u nekoj od prijavljenih obaveza , ako je i to 
                    // uredu onda se dodaje obaveza u listu prijavljenih
                    // i miče iz liste obaveza za prijavu
                    if (lb1.SelectedItem != null && vrijednost)
                    {
                        if (vrijeme)
                        {
                            int index1 = lb1.SelectedIndex;
                            lb2.Items.Add(lb1.SelectedItem);
                            lb1.Items.RemoveAt(index1);
                        }
                        else
                        {
                            // U slucaju da je vrijeme false tj da postoji neka obaveza sa istim vremenom
                            // onda se brise prijava iz liste prijavljenih
                            // i ispisuje poruka
                            DatotekaPrijave odjava = new DatotekaPrijave(user, lb1.SelectedItem, false);
                            MessageBox.Show("Vec imate prijavljenu obavezu u tom periodu", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                // labela za minute se promijeni i refresha
                lab6.Text = reg.PromijeniMinute().ToString();
                lab6.Refresh();
            }
       
            // Ako je označena neka obaveza u Listboxu1 onda se ona prebacuje u 
            // Listbox2 i miče iz trenutnog listboca
            
        }

        /* Metoda koja se poziva u trenutku kada je 
         * kliknut About item u meniju 
         */
        private void about1(Object Sender, EventArgs e)
        {
            // Instanciramo klasu About te ju prikazujemo
            About ab = new About();
            ab.Show();
        }

        /* Metoda koja se poziva kada je kliknut gumb Odjava */
        private void btn2_Clicked(Object Sender, EventArgs e)
        {
            if (lb2.SelectedItem != null)
            {
                RegulatorMinuta reg = new RegulatorMinuta(user);
                LinkedList<string> listaIstek = new LinkedList<string>();

                // spremamo istekle obaveze
                listaIstek = auto.ProvjeraRoka();
                bool vrijednost = true;

                foreach (var item in listaIstek)
                {
                    string[] item2 = item.Split(' ');

                    // Ako postoji neka obaveza u listi isteklih
                    if (item2[1].Equals(VratiID(lb2.SelectedItem.ToString())))
                    {
                        // Prikazujemo poruku , pokrecemo automatsko funkciju te brisemo iz liste prijavljenih
                        MessageBox.Show("Za izabranu obavezu je rok istekao", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vrijednost = false;
                        auto.Automatsko();
                        int index2 = lb2.SelectedIndex;
                        lb2.Items.RemoveAt(index2);
                        lb2.Refresh();
                        break;
                    }
                }

                // odjavimo selektiranu obavezu
                DatotekaPrijave odjava = new DatotekaPrijave(user, lb2.SelectedItem, false);

                // Ako je označena neka obaveza u Listboxu2 onda se ona prebacuje u ListBox1 
                // i miče iz trenutnog listboxa
                if (lb2.SelectedItem != null && vrijednost)
                {

                    int index2 = lb2.SelectedIndex;
                    lb1.Items.Add(lb2.SelectedItem);
                    lb2.Items.RemoveAt(index2);
                }
                else
                {
                    //selektiranu obavezu dodamo nazad u listu prijavljenih ako je doslo do greske
                    DatotekaPrijave prijava = new DatotekaPrijave(user, lb2.SelectedItem, true);
                }

                // osvježavamo minute
                lab6.Text = reg.PromijeniMinute().ToString();
                lab6.Refresh();

            }
        }

        /* Metoda se poziva kada je kliknut item u meniju Exit */
        public void exit1(Object Sender, EventArgs e)
        {
            Application.Exit();
        }

        /* Metoda se poziva kada je kliknut item u meniju Refresh */
        public void ref1(Object Sender, EventArgs e)
        {
            this.Refresh();
        }

        /* Funkcija prima listu obaveza i dodaje praznine 
         * koje su nam potrebne za prikaz u Listboxu . Kad ne
         * bi napravili ovu funkciju stringovi obaveza bi u programu 
         * imali samo jedan razmak između termina , sati ..
         */
        public string[] NapraviString(LinkedList<string> Lista)
        {
            // deklariramo novo polje i integere
            string[] polje = new string[100];
            int i = 0, len1, max = 0;

            // Određujemo najdulju dužinu prvog stringa u obavezama(Ispravljanje, meduispit .. )
            // da bi učinkovito popunili prazninama tj. da ne bi bio neravan izgled
            foreach (var item in Lista)
            {
                string[] item2 = item.Split(' ');
                if (max < item2[0].Length)
                {
                    max = item2[0].Length;
                }
            } 

            // Prvo dodajemo tom prvom stringu praznina koliko treba da bi izgledalo poravnato
            // a onda svim ostalima jednaki broj praznina zato sto su termini , ID termina iste duljine
            foreach (var item in Lista)
            {
                string[] item2 = item.Split(' ');
                len1 = item2[0].Length;
                int suma = 7 + max - len1; // 5 praznina je temelj + još onoliko praznina da bi izgledalo poravnato sa najduljom duljinom stringa
                polje[i] = item2[0];

                while (suma != 0)
                {
                    polje[i] += " ";
                    --suma;
                }
                int k = 0;

                // ovdje dodajemo svim preostalim itemima u stringu obaveze jednaki broj praznina
                foreach (var item3 in item2)
                {
                    if (k != 0 && item3 != "")
                    {
                        polje[i] += item3 + "          ";
                    }

                    ++k;
                }
                ++i;
            }
            return polje;
        }

        /* Funkcija služi za vraćanje ID obaveze , a predamo mu
         * a predamo joj string sa obavezom 
         */
        public string VratiID(string str1)
        {
            // Replace radimo da skratimo vrćenje u petlji 
            string str2 = str1.Replace("      ", " ");
            
            // Razdvajamo po prazninama obavezu
            string[] str = str1.Split(' ');
            int k = 0, p = 0;
            foreach (var item in str)
            {
                // provjeravamo da li je prazan string , to nam ne treba
                if (item != "")
                {
                    if (k == 1)
                    {
                        return item;
                    }
                    ++k;
                }
                ++p;
            }

            // Funkcija ce sigurno nesto vratit u petlji , ali moramo i ovaj
            // prazan string stavit da bi radilo
            return "";
        }

        /* Funkcija koja se poziva kada se pritisne Menutipka
         * AutoRaspored
         */
        public void Autom(Object Sender, EventArgs e)
        {
            RegulatorMinuta reg = new RegulatorMinuta(user);
            auto.Automatsko();
            lb1.Items.Clear();
            Textbox_dodavanje_Prijava(dat.datotekaVratiObaveze1(), dat.datotekaVratiObaveze2(user));
            lab6.Text = reg.PromijeniMinute().ToString();
        }

        public void AddO(Object Sender, EventArgs e)
        {
            RegulatorMinuta reg = new RegulatorMinuta(user);
            AddObaveze addo = new AddObaveze(exe, user);
            if (addo.ShowDialog() == DialogResult.OK)
            {
                lb1.Items.Clear();
                Textbox_dodavanje_Prijava(dat.datotekaVratiObaveze1(), dat.datotekaVratiObaveze2(user));
                lab6.Text = reg.PromijeniMinute().ToString();
            }
        }

        #endregion
    }
}
