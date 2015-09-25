using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Raspored_asistenti_demonstratori
{
    class Register : Put
    {
        private TextBox tex1 = new TextBox();
        private TextBox tex2 = new TextBox();
        private TextBox tex3 = new TextBox();
        private TextBox tex4 = new TextBox();
        private TextBox tex5 = new TextBox();

        private Label lb1 = new Label();
        private Label lb2 = new Label();
        private Label lb3 = new Label();
        private Label lb4 = new Label();
        private Label lb5 = new Label();

        private ComboBox comb = new ComboBox();

        private Button btnOK = new Button();
        private Button btnCancel = new Button();

        public Register()
        {
            string exepath2 = Application.StartupPath + @"\diigo.ico";

            this.Width = 340;
            this.Height = 470;
            this.Text = "Registracija";
            this.Location = new Point(Screen.GetWorkingArea(this).Height / 2, Screen.GetWorkingArea(this).Width / 8);
            this.Icon = new Icon(exepath2);

            lb1.Text = "Asistent ili Demonstrator :";
            lb1.Location = new Point(25, 50);
            lb1.Font = new Font("Arial", 10, FontStyle.Regular);
            lb1.Width = 200;

            comb.Items.Add("A");
            comb.Items.Add("D");
            comb.Location = new Point(215, 50);
            comb.Text = "  Izaberi ..";
            comb.Width = 70;

            lb2.Text = "Upisite ID :  \n\n*5 znamenki ";
            lb2.Location = new Point(25, 120);
            lb2.Font = new Font("Arial", 10, FontStyle.Regular);
            lb2.Width = 150;
            lb2.Height = 60;

            tex2.Location = new Point(190, 120);
            tex2.Width = 100;

            tex3.Location = new Point(190, 190);
            tex3.Width = 100;

            tex4.Location = new Point(190, 260);
            tex4.Width = 100;

            tex5.Location = new Point(190, 330);
            tex5.Width = 100;

            lb3.Text = "Upisite username : ";
            lb3.Location = new Point(25, 190);
            lb3.Font = new Font("Arial", 10, FontStyle.Regular);
            lb3.Width = 150;

            lb4.Text = "Upisite password : ";
            lb4.Location = new Point(25, 260);
            lb4.Font = new Font("Arial", 10, FontStyle.Regular);
            lb4.Width = 150;

            lb5.Text = "Upisite opterećenje : ";
            lb5.Location = new Point(25, 330);
            lb5.Font = new Font("Arial", 10, FontStyle.Regular);
            lb5.Width = 150;

            btnOK.Text = "OK";
            btnOK.Width = 130;
            btnOK.Height = 30;
            btnOK.Location = new Point(30, 390);
            btnOK.Click += new EventHandler(this.btnO);

            btnCancel.Text = "Cancel";
            btnCancel.Width = 130;
            btnCancel.Height = 30;
            btnCancel.Location = new Point(170, 390);
            btnCancel.Click += new EventHandler(this.btnC);

            this.Controls.Add(btnCancel);
            this.Controls.Add(btnOK);
            this.Controls.Add(lb4);
            this.Controls.Add(lb5);
            this.Controls.Add(lb3);
            this.Controls.Add(tex2);
            this.Controls.Add(tex3);
            this.Controls.Add(tex4);
            this.Controls.Add(tex5);
            this.Controls.Add(lb2);
            this.Controls.Add(comb);
            this.Controls.Add(lb1);
        }

        // funkcija koja služi da se makne prozor
        private void btnC(Object Sender, EventArgs e)
        {
            this.Hide();
        }

        // ako se pritisne OK onda se zapisuju podaci u datoteke prijave.txt i obeveze.txt
        private void btnO(Object Sender, EventArgs e)
        {
            string linija, linija2;

            // ako su popunjena sva polja
            if (tex2.TextLength > 0 && tex3.TextLength > 0 && tex4.TextLength > 0 && tex5.TextLength > 0 && comb.SelectedItem != null)
            {
                // ako je ID jednak 5
                if (tex2.TextLength == 5)
                {
                    if (tex5.Text.IndexOf('.') != -1)
                    {
                        // napravi string po uzoru na one iz datoteke obeveze.txt
                        linija = comb.SelectedItem.ToString() + ";" + tex2.Text + ";" + tex3.Text + ";" + tex4.Text + ";" + tex5.Text;

                        FileStream aFile = new FileStream(put + @"\ad.txt", FileMode.Append, FileAccess.Write);
                        StreamWriter Sw = new StreamWriter(aFile);

                        Sw.WriteLine("");   // zapisujemo
                        Sw.Write(linija);
                        Sw.Close();
                        aFile.Close();

                        FileStream aFile2 = new FileStream(put + @"\prijave.txt", FileMode.Append, FileAccess.Write);
                        StreamWriter Sw2 = new StreamWriter(aFile2);

                        // pravimo string "user;"
                        linija2 = tex3.Text + ";";

                        Sw2.WriteLine("");  // zapisujemo
                        Sw2.Write(linija2);
                        Sw2.Close();
                        aFile2.Close();

                        // Gasimo
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Opterecenje mora biti tipa doubel npr. {znamenka}{znamenka}*.{znamenka}{znamenka}*  , znamenka -> 0|1|2|3|4|5|6|7|8|9", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Poruka greska
                    MessageBox.Show("ID mora biti sa 5 znamenaka npr. 55555", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Niste ispunili sva polja", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
