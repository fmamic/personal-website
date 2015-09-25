using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PPIJServicesLibrary;
using PPIJServicesLibrary.Data;
using PPIJServicesLibrary.Connection;
using PPIJServicesLibrary.PPIJBoard;
using PPIJServicesLibrary.Services;

namespace SocialNetworkingClient
{
    public partial class SocialNetworksManager : Form
    {
        private TwitterConnection twittersender = new TwitterConnection();
        private PpijBoardConnection ppijsender = new PpijBoardConnection();
        private FileManagment filemanagment = new FileManagment();

        public SocialNetworksManager()
        {
            InitializeComponent();
            linkTwitter.Text = twittersender.gettwitterURI;
        }

        private void posaljiTwitter_Click(object sender, EventArgs e)
        {
            twittersender.loadTwitterToken(pinTwitter.Text, porukaTwitter.Text);
            twittersender.Send();
        }

        private void posaljiPpij_Click(object sender, EventArgs e)
        {
            if (texboxBrojOdgovorappij.Text == "")
            {
                ppijsender.loadPpijToken(textboximeAutora.Text, texboxporukappij.Text);
            }
            else
            {
                ppijsender.loadPpijToken(textboximeAutora.Text, texboxporukappij.Text, texboxBrojOdgovorappij.Text);
            }
            ppijsender.Send();
        }

        private void obrisiDatoteku_Click(object sender, EventArgs e)
        {
            filemanagment.EraseFile();
        }
    }

}