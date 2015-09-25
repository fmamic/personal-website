using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicesLibrary.Data
{
    public class TwitterTokens
    {
        private string accessToken;

        public string AccessToken
        {
            get { return accessToken; }
            set { accessToken = value; }
        }
        private string accessTokenSecret;

        public string AccessTokenSecret
        {
            get { return accessTokenSecret; }
            set { accessTokenSecret = value; }
        }
        private string consumerSecret;

        public string ConsumerSecret
        {
            get { return consumerSecret; }
            set { consumerSecret = value; }
        }
        private string consumerKey;

        public string ConsumerKey
        {
            get { return consumerKey; }
            set { consumerKey = value; }
        }

        private string requesttoken;

        public string Requesttoken
        {
            get { return requesttoken; }
            set { requesttoken = value; }
        }

        private string authenticationURI;

        public string AuthenticationURI
        {
            get { return authenticationURI; }
            set { authenticationURI = value; }
        }

        private TwitterTokens acessTwitterToken;

        public TwitterTokens AccessTwitterToken
        {
            get { return acessTwitterToken; }
            set { acessTwitterToken = value; }
        }
    }
}
