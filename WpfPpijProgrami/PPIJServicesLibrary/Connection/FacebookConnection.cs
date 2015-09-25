using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using PPIJServicesLibrary.Data;

namespace PPIJServicesLibrary.Connection
{
    public class FacebookConnection : IInterface
    {
        FacebookData facebookData;
        FacebookClient facebookClient;

        public FacebookConnection()
        {
            facebookData = new FacebookData();    
        }

        public void SetFacebookMessage(string message)
        {
            facebookData.Message = message;
        }

        public void FacebookToken(string accessToken)
        {
            facebookData.Token = accessToken;
        }

        public void LoadTokens()
        {
        }

        public void Send()
        {
            string pageID = "PPIJ2012";
            
            facebookClient = new FacebookClient(facebookData.Token);
            facebookClient.Post(pageID + "/feed", new { message = facebookData.Message });
            
        }
    }
}
