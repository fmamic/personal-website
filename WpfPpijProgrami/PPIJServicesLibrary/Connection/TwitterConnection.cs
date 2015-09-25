using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPIJServicesLibrary.Data;
using PPIJServicesLibrary.Services;
using System.IO;

namespace PPIJServicesLibrary.Connection
{
    public class TwitterConnection : IInterface
    {
        private TwitterTokens twittertokeni = new TwitterTokens();
        private TwitterData twittermessagedata = new TwitterData();
        private FileManagment filemanagment = new FileManagment();

        public TwitterConnection()
        {
            LoadTokens();
        }
        public void LoadTokens()
        {
            TextReader readTokenFromFile = new StreamReader(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\twittertokeni.txt");
            twittertokeni.ConsumerKey = readTokenFromFile.ReadLine();
            twittertokeni.ConsumerSecret = readTokenFromFile.ReadLine();
            twittertokeni.Requesttoken = TwitterService.GetRequestToken(twittertokeni.ConsumerKey, twittertokeni.ConsumerSecret);
            twittertokeni.AuthenticationURI = TwitterService.GetAuthorizationUri(twittertokeni.Requesttoken);
        }
        public void loadTwitterToken(string twitterPIN)
        {
            twittermessagedata.PIN = twitterPIN;
        }

        public void SetTwitterMessage(string message)
        {
            twittermessagedata.Message = message;
        }

        public void loadTwitterToken(string twitterPIN, string poruka)
        {
            twittermessagedata.Message = poruka;
            twittermessagedata.PIN = twitterPIN;
        }
        public void Send()
        {
            TwitterService.Tweet(twittertokeni.AccessTwitterToken, twittermessagedata.Message);
        }

        public void SetToken()
        {
            try
            {
                int accesstokenNum = 0;
                int accesstokenSecretNum = 1;
                string[] accessToken = filemanagment.ReadAccessTokenTwitterFromFile();

                if (accessToken[accesstokenNum] == "" || accessToken[accesstokenNum] == null)
                {
                    twittertokeni.AccessTwitterToken = TwitterService.GetAccessToken(twittertokeni.ConsumerKey, twittertokeni.ConsumerSecret, twittertokeni.Requesttoken, twittermessagedata.PIN);
                    filemanagment.SaveAccessTokenTwitterToFile(twittertokeni.AccessTwitterToken.AccessToken, twittertokeni.AccessTwitterToken.AccessTokenSecret);
                }
                else
                {
                    twittertokeni.AccessToken = accessToken[accesstokenNum];
                    twittertokeni.AccessTokenSecret = accessToken[accesstokenSecretNum];
                    twittertokeni.AccessTwitterToken = twittertokeni;
                }
            }
            catch
            {
                Console.WriteLine("Nije dohvaćen pristupni token");
            }
        }

        public string gettwitterURI
        {
            get { return twittertokeni.AuthenticationURI; }
        }

        public List<TwitterUserProfile> getTwitterFriends()
        {
            return TwitterService.GetFollowers(twittertokeni);
        }
    }
}
