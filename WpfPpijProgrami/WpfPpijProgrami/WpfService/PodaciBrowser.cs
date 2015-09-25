using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfPpijProgrami
{
    class PodaciBrowser
    {
        public static string accessTokenFacebook;

        private string uriAdress;

        public string UriAdress
        {
            get { return uriAdress; }
            set { uriAdress = value; }
        }
    }
}
