using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using PPIJServicesLibrary.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using System.Linq;

namespace PPIJServicesLibrary.Services
{
    public class FacebookServiceGet
    {
        public List<FacebookFriends> ParseFriends(string token)
        {
            FacebookClient facebookClient = new FacebookClient(token);
            string friends = facebookClient.Get("me/friends").ToString();

            JObject jsonFriends = JObject.Parse(friends);
            List<FacebookFriends> facebookFriends = new List<FacebookFriends>();

            int brojac = 0;
            foreach (var friend in jsonFriends["data"].Children())
            {
                FacebookFriends faceFriends = new FacebookFriends();
                faceFriends.Id = friend["id"].ToString();
                faceFriends.Name = friend["name"].ToString();

                JObject jsonFriend = JObject.Parse(facebookClient.Get("/" + faceFriends.Id).ToString());
                try
                {
                    faceFriends.Gender = jsonFriend["gender"].ToString();
                }
                catch 
                {
                    faceFriends.Gender = "";
                }
                
                faceFriends.Date = jsonFriend["updated_time"].ToString();

                facebookFriends.Add(faceFriends);
                brojac++;

                if (brojac > 5)
                {
                    break;
                }
            }

            return facebookFriends;

        }
    }
}
