using System;
using PPIJServicesLibrary.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfPpijProgrami
{
    public class Podaci : INotifyPropertyChanged
    {

        public static string uriFacebook = @"https://www.facebook.com/dialog/oauth?client_id=300897673331353&scope=publish_stream&redirect_uri=http://www.facebook.com/connect/login_success.html&response_type=token";
        public static string uriTwitter;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private string pin;

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        private bool isTwitter;

        public bool IsTwitter
        {
            get { return isTwitter; }
            set { isTwitter = value; }
        }

        private bool isFacebook;

        public bool IsFacebook
        {
            get { return isFacebook; }
            set { isFacebook = value; }
        }

        private bool isPpijBoard;

        public bool IsPpijBoard
        {
            get { return isPpijBoard; }
            set { isPpijBoard = value; }
        }

        private string tekstPoruke;

        public string TekstPoruke
        {
            get { return tekstPoruke; }
            set { tekstPoruke = value; }
        }

        private string imeAutora;

        public string ImeAutora
        {
            get { return imeAutora; }
            set
            {
                if (value != this.imeAutora)
                {
                    this.imeAutora = value;
                    NotifyPropertyChanged("ImeAutora");
                }
            }
        }

        private string ppijReplayNumber;

        public string PpijReplayNumber
        {
            get { return ppijReplayNumber; }
            set { ppijReplayNumber = value; }
        }

        private List<FacebookFriends> facebookFriends;

        public List<FacebookFriends> FacebookFriends
        {
            get { return facebookFriends; }
            set { facebookFriends = value; }
        }

        private List<TwitterUserProfile> twitterFriends;

        public List<TwitterUserProfile> TwitterFriends
        {
            get { return twitterFriends; }
            set { twitterFriends = value; }
        }

        private List<PpijBoardFriends> ppijFriends;

        public List<PpijBoardFriends> PpijFriends
        {
            get { return ppijFriends; }

            set
            {
                if (value != this.ppijFriends)
                {
                    this.ppijFriends = value;
                    NotifyPropertyChanged("PpijFriends");
                }
            }
        }
    }
}
