using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPIJServicesLibrary.Data
{
    public class PpijBoadrData : MessageData
    {
        private string nameAutor;

        public string NameAutor
        {
            get { return nameAutor; }
            set { nameAutor = value; }
        }

        private bool isAnswer;

        public bool IsAnswer
        {
            get { return isAnswer; }
            set { isAnswer = value; }
        }

        private string replaynumber;

        public string Replaynumber
        {
            get { return replaynumber; }
            set { replaynumber = value; }
        }
    }

    public class TwitterData : MessageData
    {
        private string pin;

        public string PIN
        {
            get { return pin; }
            set { pin = value; }
        }
    }

    public class FacebookData : MessageData
    {
        private string accessToken;

        public string Token
        {
            get { return accessToken; }
            set { accessToken = value; }
        }
    }
}
