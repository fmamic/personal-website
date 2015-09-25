using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitterizer;
using Newtonsoft.Json;
using ServicesLibrary.Data;

namespace ServicesLibrary.Services
{
    public static class TwitterService
    {

        /// <summary>
        /// Dohvaća Twitter request token na osnovu danih podataka za aplikaciju
        /// </summary>
        /// <param name="ConsumerKey">Consumer Key aplikacije - kopirati sa Twitter dev stranica</param>
        /// <param name="ConsumerSecret">Consumer Secret aplikacije - kopirati sa Twitter dev stranica</param>
        /// <returns>Request token</returns>
        public static string GetRequestToken(string ConsumerKey, string ConsumerSecret)
        {
            OAuthTokenResponse requestToken = OAuthUtility.GetRequestToken(ConsumerKey, ConsumerSecret, "oob");
            return requestToken.Token;
        }

        /// <summary>
        /// Generira URI za autorizaciju na osnovu danog request tokena. 
        /// </summary>
        /// <param name="RequestToken">Request token</param>
        /// <returns>URI za autorizaciju - prikazati korisniku</returns>
        public static string GetAuthorizationUri(string RequestToken)
        {
            return OAuthUtility.BuildAuthorizationUri(RequestToken).AbsoluteUri;
        }

        /// <summary>
        /// Dohvaća access token - potrebno je dobiti PIN putem stranice za autorizaciju
        /// </summary>
        /// <param name="ConsumerKey">Consumer key aplikacije</param>
        /// <param name="ConsumerSecret">Consumer secret aplikacije</param>
        /// <param name="RequestToken">Request token na temelju kojeg je generiran zahtjev</param>
        /// <param name="PIN">Potvrdni PIN sa Twittera</param>
        /// <returns>Access Token</returns>
        public static TwitterTokens GetAccessToken(string ConsumerKey, string ConsumerSecret, string RequestToken, string PIN)
        {
            OAuthTokenResponse accessToken = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, RequestToken, PIN);
            TwitterTokens tokeni = new TwitterTokens();

            tokeni.AccessToken = accessToken.Token;
            tokeni.AccessTokenSecret = accessToken.TokenSecret;
            tokeni.ConsumerSecret = ConsumerSecret;
            tokeni.ConsumerKey = ConsumerKey;

            return tokeni;
        }

        /// <summary>
        /// Postavlja novi tweet online.
        /// </summary>
        /// <param name="AccessToken">Access token koji dopušta postavljanje tweeta na stranice korisnika</param>
        /// <param name="Message">Sadržaj tweeta - moguće korsistiti hash-tagove i sl. mogućnosti</param>
        /// <returns>Potvrda da li je postavljanje uspjelo</returns>
        public static bool Tweet(TwitterTokens AccessToken, string Message)
        {
            try
            {
                TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(convertTwitterToOAuthToken(AccessToken), Message);
                if (tweetResponse.Result == RequestResult.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("TweetException");
            }
            return false;
        }

        private static OAuthTokens convertTwitterToOAuthToken(TwitterTokens twTokens)
        {
            OAuthTokens returnTokens = new OAuthTokens() { AccessToken = twTokens.AccessToken, AccessTokenSecret = twTokens.AccessTokenSecret, ConsumerKey = twTokens.ConsumerKey, ConsumerSecret = twTokens.ConsumerSecret };
            return returnTokens;
        }

        /// <summary>
        /// Dohvaća pratitelje trenutnog korisnika
        /// </summary>
        /// <param name="AccessToken">
        /// Access token povezan sa računom trenutnog korisnika
        /// </param>
        /// <returns>Lista profila pratitelja trenutnog korisnika</returns>
        public static List<TwitterUserProfile> GetFollowers(TwitterTokens AccessToken)
        {
            TwitterResponse<UserIdCollection> followersResponse =
                TwitterFriendship.FollowersIds(
                    convertTwitterToOAuthToken(AccessToken));
            if (followersResponse.Result == RequestResult.Success)
            {
                List<TwitterUserProfile> followers = new List<TwitterUserProfile>();
                LookupUsersOptions lookupOptions = new LookupUsersOptions();
                // Loop through all of the follower user ids
                for (int index = 0;
                                    index < followersResponse.ResponseObject.Count;
                index++)
                {
                    // We can only look up 100 users at a time
                    if ((index % 100 == 0) && (index != 0))
                    {
                        getAndConvertPartialUserList(AccessToken, followers, lookupOptions);
                        // Clear the lookup user ids
                        lookupOptions.UserIds.Clear();
                    }
                    lookupOptions.UserIds.Add(
                                            followersResponse.ResponseObject[index]);
                }
                if (lookupOptions.UserIds.Count > 0)
                    getAndConvertPartialUserList(AccessToken,
                        followers, lookupOptions);

                return followers;
            }
            else
            {
                throw new Exception(followersResponse.ErrorMessage);
            }
        }

        private static void getAndConvertPartialUserList(TwitterTokens AccessToken, List<TwitterUserProfile> followers, LookupUsersOptions lookupOptions)
        {
            TwitterResponse<TwitterUserCollection> userLookupResponse = TwitterUser.Lookup(convertTwitterToOAuthToken(AccessToken), lookupOptions);
            if (userLookupResponse.Result == RequestResult.Success)
            {
                foreach (TwitterUser user in userLookupResponse.ResponseObject)
                {
                    followers.Add(new TwitterUserProfile()
                    {
                        Description = user.Description,
                        Id = user.Id,
                        Language = user.Language,
                        Location = user.Location,
                        Name = user.Name,
                        NumberOfFriends = user.NumberOfFriends,
                        NumberOfStatuses = user.NumberOfStatuses,
                        ProfileImageLocation = user.ProfileImageLocation,
                        ProfileSecureImageLocation = user.ProfileImageSecureLocation,
                        ScreenName = user.ScreenName,
                        Status = user.Status.Text,
                        Website = user.Website
                    });
                }
            }
        }
    }
}
