using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPIJServicesLibrary.Data
{
    public class PPIJservicetokens
    {
        private string accessTokenppij;

        public string AccessTokenppij
        {
            get { return accessTokenppij; }
            set { accessTokenppij = value; }
        }

        private string appkeyppij;

        public string Appkeyppij
        {
            get { return appkeyppij; }
            set { appkeyppij = value; }
        }
    }
}
