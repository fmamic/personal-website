using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Raspored_asistenti_demonstratori
{
    public partial class AddObaveze : Form
    {
        public string put;
        protected string user;

        public AddObaveze(string Put, string User)
        {
            put = Put;
            user = User;

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string linija;

            if (tb1.TextLength > 0 && tb2.TextLength > 0 && tb3.TextLength > 0 && tb4.TextLength > 0 && tb5.TextLength > 0 && tb6.TextLength > 0 && tb7.TextLength > 0)
            {
                if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox6.SelectedItem != null && comboBox7.SelectedItem != null && comboBox8.SelectedItem != null)
                {
                    RegulatorMinuta reg = new RegulatorMinuta(user);

                    linija = tb1.Text + ";" + tb2.Text + ";" + comboBox1.SelectedItem + "." + comboBox2.SelectedItem + "." + comboBox3.SelectedItem + ".-" + comboBox4.SelectedItem + ":" + comboBox5.SelectedItem + ";" + tb3.Text + ";" + tb4.Text + ";";
                    linija += tb5.Text + ";" + tb6.Text + ";" + tb7.Text + ";" + comboBox6.SelectedItem + ":" + comboBox8.SelectedItem;
                    linija += ";" + comboBox7.SelectedItem + ":" + comboBox9.SelectedItem;

                    FileStream aFile = new FileStream(put + @"\obaveze.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter Sw = new StreamWriter(aFile);

                    Sw.WriteLine("");   // zapisujemo
                    Sw.Write(linija);
                    Sw.Close();
                    aFile.Close();

                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Odaberite sve sate i minute", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ispunite sve texboxove", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
