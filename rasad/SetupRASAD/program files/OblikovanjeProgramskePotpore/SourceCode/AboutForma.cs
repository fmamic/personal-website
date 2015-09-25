using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Raspored_asistenti_demonstratori
{
    /* Klasa koja također nasljeđuje Formu za 
     * ostvarivanje grafickog sucelja . Instancira se kada
     * korisnik klikne na Help-> About u Menu 
     */
    class About : Form
    {
        private Button close = new Button();
        private PictureBox pb1 = new PictureBox();
        private GroupBox gb1 = new GroupBox();
        private Label lb1 = new Label();
        private Label lb2 = new Label();
        private Label lb3 = new Label();
        private Label lb4 = new Label();

        public About()
        {
            // pridjeljujemo vrijednosti za graficko uređenje
            // slično kao i kod login i glavne forme
            string exepath1 = Application.StartupPath + @"\slika.jpg";
            string exepath2 = Application.StartupPath + @"\diigo.ico";

            this.Width = 570;
            this.Height = 590;
            this.Text = "O programu";
            this.Location = new Point(Screen.GetWorkingArea(this).Height / 3, Screen.GetWorkingArea(this).Width / 10);
            this.Icon = new Icon(exepath2);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            gb1.Location = new Point(14, 14);
            gb1.Text = "Slika";
            gb1.Width = 200;
            gb1.Height = 500;

            lb1.Location = new Point(250, 150);
            lb1.Width = 500;
            lb1.Font = new Font("Arial", 10, FontStyle.Regular);
            lb1.Text = "Name : Program za rasporedivanje obaveza";

            lb2.Location = new Point(250, 200);
            lb2.Width = 500;
            lb2.Font = new Font("Arial", 10, FontStyle.Regular);
            lb2.Text = "Version : 1.0.4";

            close.Width = 200;
            close.Text = "Zatvori";
            close.Height = 30;
            close.Location = new Point(280, 480);
            close.Click += new EventHandler(this.close1);

            pb1.Location = new Point(10, 23);
            pb1.Width = 170;
            pb1.Height = 450;
            pb1.Image = Image.FromFile(exepath1);

            this.Controls.Add(lb2);
            this.Controls.Add(lb1);
            this.Controls.Add(close);
            gb1.Controls.Add(pb1);
            this.Controls.Add(gb1);

        }

        // funkcija koja služi da se makne prozor
        private void close1(Object Sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
