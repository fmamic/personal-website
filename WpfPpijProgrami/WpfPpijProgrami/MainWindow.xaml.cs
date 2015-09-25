using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using PPIJServicesLibrary.Connection;
using PPIJServicesLibrary.Data;
using PPIJServicesLibrary.Services;
using WpfPpijProgrami.WpfService;

namespace WpfPpijProgrami
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Initialize
        Podaci podaci;
        TwitterConnection twitterConnection;
        PpijBoardConnection ppijConnection;
        FacebookConnection facebookConnection;
        FacebookServiceGet getFriends = new FacebookServiceGet();
        ListBoxFacebook addListBoxFacebook = new ListBoxFacebook();
        ListBoxTwitter addListBoxTwitter = new ListBoxTwitter();
        ListBoxPpijBoard addListBoxPpij = new ListBoxPpijBoard();
        ExtendedService extendedService = new ExtendedService();
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            InitializeConnections();
        }


        #region Buttons

        //Browser
        private void Button_Click_Browser(object sender, RoutedEventArgs e)
        {
            string network = setNetworkName();
            newThread(network);
        }

        private void Button_Click_Send(object sender, RoutedEventArgs e)
        {
            string network = setNetworkName();

            if (network != "")
            {
                Send(network);
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clear();
            extendedService.extendedListBoxInfo(tb1, tb2, tb3, 
                tb4, tb5, tb6, listBox, podaci);
        }

        private void MenuItem_Click_LoadToken(object sender, RoutedEventArgs e)
        {
            bool allTaken = true;
            bool someTaken = false;
            List<string> nameList = new List<string>();

            LoadToken(ref allTaken, ref someTaken);

            if (PodaciBrowser.accessTokenFacebook != null)
            {
                podaci.FacebookFriends = getFriends.ParseFriends(PodaciBrowser.accessTokenFacebook);
            }
            podaci.TwitterFriends = twitterConnection.getTwitterFriends();
            podaci.PpijFriends = ppijConnection.GetPpijBoardFriends();

            addToListBox(nameList);
        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }


        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = search.Text.ToLower();
            
            List<string> list = new List<string>();

            //PLINQ
            plinqExtract(searchText, list);

            //Merge Sort
            list = mergeSort(list);

            //Listbox Adding
            listBox.Items.Clear();
            foreach (var item in list)
            {
                listBox.Items.Add(item);
            }
        }

        #endregion 


        #region otherMethods

        private void addToListBox(List<string> nameList)
        {
            addListBoxFacebook.AddListElements(nameList, podaci);
            addListBoxPpij.AddListElements(nameList, podaci);
            addListBoxTwitter.AddListElements(nameList, podaci);
            AddElements.addElementsListBox(nameList, listBox);
        }

        private static List<string> mergeSort(List<string> list)
        {
            var listArray = list.ToArray();

            var sorter = new ParallelMergeSort<string>();
            sorter.Sort(
              listArray,
              delegate(string value1, string value2)
              {
                  return string.Compare(value1, value2, true);
              });

            return listArray.ToList();
        }

        private void plinqExtract(string searchText, List<string> list)
        {
            try
            {
                var queryFacebook = (from names in podaci.FacebookFriends.AsParallel()
                                     let text = searchText
                                     where names.Name.ToLower().StartsWith(text.ToString())
                                     select names.Name).ToList();

                addToList(list, queryFacebook);

            }
            catch (Exception excep)
            {
                Console.WriteLine("search " + excep);
            }

            var queryTwitter = (from names in podaci.TwitterFriends.AsParallel()
                                let text = searchText
                                where names.Name.ToLower().StartsWith(text.ToString())
                                select names.Name).ToList();

            var queryPpij = (from names in podaci.PpijFriends.AsParallel()
                             let text = searchText
                             where names.Name.ToLower().StartsWith(text.ToString())
                             select names.Name).ToList();

            addToList(list, queryPpij);
            addToList(list, queryTwitter);
        }

        private void Send(string network)
        {
            if (network == "Twitter")
            {
                twitterConnection.SetTwitterMessage(podaci.TekstPoruke);
                twitterConnection.Send();
            }
            else if (network == "Facebook")
            {
                facebookConnection.SetFacebookMessage(podaci.TekstPoruke);
                facebookConnection.Send();
            }
            else if (network == "PpijBoard")
            {
                if (podaci.PpijReplayNumber == null)
                {
                    ppijConnection.loadPpijToken(podaci.ImeAutora, podaci.TekstPoruke);
                }
                else
                {
                    ppijConnection.loadPpijToken(podaci.ImeAutora, podaci.TekstPoruke, podaci.PpijReplayNumber);
                }

                ppijConnection.Send();
            }
            else
            {
                MessageBox.Show("Select a network to send");
            }
        }

        private void LoadToken(ref bool allTaken, ref bool someTaken)
        {
            try
            {
                twitterConnection.loadTwitterToken(podaci.Pin, podaci.TekstPoruke);
                twitterConnection.SetToken();
                someTaken = true;
            }
            catch
            {
                allTaken = false;
            }

            try
            {
                ppijConnection.loadPpijToken(podaci.ImeAutora, podaci.TekstPoruke, podaci.PpijReplayNumber);
                ppijConnection.SetTokens();
                someTaken = true;
            }
            catch
            {
                allTaken = false;
            }
            
            if(PodaciBrowser.accessTokenFacebook != null)
            {
                facebookConnection.FacebookToken(PodaciBrowser.accessTokenFacebook);
                someTaken = true;
            }
            else
            {
                allTaken = false;
            }

            if (allTaken)
            {
                border.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else if (someTaken)
            {
                border.Background = new SolidColorBrush(Colors.LightYellow);
            }
            else
            {
                border.Background = new SolidColorBrush(Colors.OrangeRed);
            }
        }

        public void Clear()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
        }

        private void InitializeConnections()
        {
            Thread _thread = Thread.CurrentThread;
            this.DataContext = new { ThreadID = _thread.ManagedThreadId };

            podaci = new Podaci();
            facebookConnection = new FacebookConnection();
            twitterConnection = new TwitterConnection();
            ppijConnection = new PpijBoardConnection();

            Podaci.uriTwitter = twitterConnection.gettwitterURI;
            this.DataContext = podaci;
        }

        private void addToList(List<string> list, List<string> queryList)
        {
            foreach (var item in queryList)
            {
                list.Add(item);
            }
        }

        private string setNetworkName()
        {
            string network;
            if (podaci.IsTwitter == true)
            {
                network = "Twitter";
            }
            else if (podaci.IsPpijBoard == true)
            {
                network = "PpijBoard";
            }
            else if (podaci.IsFacebook == true)
            {
                network = "Facebook";
            }
            else
            {
                network = "";
            }

            return network;
        }

        private static void newThread(string network)
        {
            Thread thread = new Thread(() =>
            {
                Window1 w = new Window1(network);
                w.Show();
                w.Closed += (sender1, e1) => w.Dispatcher.InvokeShutdown();
                System.Windows.Threading.Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        #endregion

    }
}
