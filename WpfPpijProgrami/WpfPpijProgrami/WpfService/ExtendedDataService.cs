using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfPpijProgrami.WpfService
{
    public class ExtendedService
    {
        public void extendedListBoxInfo(TextBlock tb1, TextBlock tb2, TextBlock tb3, 
            TextBlock tb4, TextBlock tb5, TextBlock tb6, ListBox listBox, Podaci podaci)
        {
            extendedInfoFacebook(tb1, tb2, tb3, tb4, listBox, podaci);
            extendedInfoTwitter(tb1, tb2, tb3, tb4, tb5, tb6, listBox, podaci);
            extendedInfoPpijBoard(tb1, tb2, tb3, tb4, tb5, tb6, listBox, podaci);

        }

        #region Methods

        private static void extendedInfoPpijBoard(TextBlock tb1, TextBlock tb2, TextBlock tb3, 
            TextBlock tb4, TextBlock tb5, TextBlock tb6, ListBox listBox, Podaci podaci)
        {
            foreach (var friend in podaci.PpijFriends)
            {
                if (friend.Name == listBox.SelectedItems[0])
                {
                    try
                    {
                        tb1.Text = "Name: " + friend.Name;
                        tb2.Text = "Time: " + friend.Time;
                        tb3.Text = "ID: " + friend.Id;
                        int counter = 0;
                        int numberOfMessage = 3;

                        foreach (var item in friend.Poruke)
                        {
                            switch (counter)
                            {
                                case 0: tb4.Text = "Msg1: " + item;
                                    break;
                                case 1: tb5.Text = "Msg2: " + item;
                                    break;
                                case 2: tb6.Text = "Msg3: " + item;
                                    break;
                            }


                            if (counter == numberOfMessage)
                            {
                                break;
                            }
                            counter++;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static void extendedInfoTwitter(TextBlock tb1, TextBlock tb2, 
            TextBlock tb3, TextBlock tb4, TextBlock tb5, TextBlock tb6, ListBox listBox, Podaci podaci)
        {
            foreach (var friend in podaci.TwitterFriends)
            {
                if (friend.Name == listBox.SelectedItems[0].ToString())
                {
                    try
                    {
                        string[] names = friend.Name.Split(' ');
                        tb1.Text = "Name: " + names[0];
                        tb2.Text = "Surname: " + names[1];
                        tb3.Text = "Language: " + friend.Language;
                        tb4.Text = "Loaction:" + friend.Location;
                        tb5.Text = "Tweet: " + friend.Status;
                        tb6.Text = "NickName: " + friend.ScreenName;
                    }
                    catch
                    {
                        Console.WriteLine("Null");
                    }
                }
            }
        }

        private static void extendedInfoFacebook(TextBlock tb1, TextBlock tb2, 
            TextBlock tb3, TextBlock tb4, ListBox listBox, Podaci podaci)
        {
            foreach (var friend in podaci.FacebookFriends)
            {
                if (friend.Name == listBox.SelectedItems[0].ToString())
                {
                    try
                    {
                        string[] names = friend.Name.Split(' ');
                        tb1.Text = "name: " + names[0];
                        tb2.Text = "surname: " + names[1];
                        tb3.Text = "gender: " + friend.Gender;
                        tb4.Text = "date:" + friend.Date;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Double Click Facebook " + e);
                    }
                }
            }
        }

        #endregion
    }
}
