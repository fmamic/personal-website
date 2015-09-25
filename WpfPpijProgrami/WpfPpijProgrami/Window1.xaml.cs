using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace WpfPpijProgrami
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private PodaciBrowser podaciBrowser;
        protected string networkName;

        public Window1(string network)
        {
            InitializeComponent();

            networkName = network;
            podaciBrowser = new PodaciBrowser();
            this.DataContext = podaciBrowser;
            podaciBrowser.UriAdress = Network(network);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(this.addressTextBox.Text, UriKind.RelativeOrAbsolute);

            if (!uri.IsAbsoluteUri)
            {
                MessageBox.Show("The Address URI must be absolute eg 'http://www.microsoft.com'");
                return;
            }

            this.myWebBrowser.Navigate(uri);
        }

        private string Network(string network)
        {
            if (network == "Facebook")
            {
                return Podaci.uriFacebook;
            }
            else if (network == "Twitter")
            {
                return Podaci.uriTwitter;
            }
            else if (network == "PpijBoard")
            {
                return "http://nihao.fer.hr/PPIJboard/";
            }

            return "http://www.google.hr";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (networkName == "Facebook")
            {
                string[] splitUri = myWebBrowser.Source.AbsoluteUri.Split('=');
                string[] splitUri2 = splitUri[1].Split('&');
                PodaciBrowser.accessTokenFacebook = splitUri2[0];
                Console.WriteLine(PodaciBrowser.accessTokenFacebook);
            }
        }
    }
}
