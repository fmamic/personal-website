using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Data
{
    public class PPIJmessageData : MessageData
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

    public class TwitterMessageData : MessageData
    {
        private string pin;

        public string PIN
        {
            get { return pin; }
            set { pin = value; }
        }
    }
}
