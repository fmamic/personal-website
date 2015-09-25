using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPIJServicesLibrary.PPIJBoard;
using System.IO;

namespace PPIJServicesLibrary.Services
{
    /// <summary>
    /// Statična servisna klasa za komunikaciju sa PPIJBoardom - služi kao lagani omotač (wrapper) oko klijenta prikladnog web servisa
    /// </summary>
    public static class PPIJBoardService
    {
        
        /// <summary>
        /// Generira pristupni token za aplikaciju. Ukoliko aplikacija nije pronađena, baca AppNotFoundException, a ukoliko već postoji aktivni token ActiveTokenException.
        /// </summary>
        /// <param name="ApplicationKey">Aplikacijski ključ korisnikove aplikacije</param>
        /// <returns>Pristupni token</returns>
        public static string GetAccessToken(string ApplicationKey)
        {
            FileManagment loadAccessTokenFromFile = new FileManagment();
            try
            {
                PPIJboardServiceSoapClient client = new PPIJboardServiceSoapClient();
                return client.GetAccessToken(ApplicationKey);
            }
            catch (Exception accessTokenException)
            {
                if (accessTokenException.Message.Contains("valjani token postoji"))
                { 
                    return loadAccessTokenFromFile.ReadAccessTokenppijFromFile();
                }
                else
                {
                    Console.WriteLine("AppNotFoundException");
                    return null;
                }
            }
        }

        /// <summary>
        /// Dohvaća zadnjih nekoliko poruka na PPIJboardu u prikladnom formatu. Ukoliko je token istekao ili krivi, baca TokenNotValidException.
        /// </summary>
        /// <param name="token">Pristupni token</param>
        /// <param name="count">Broj poruka za dohvatiti</param>
        /// <returns>Poruke sa PPIJboarda</returns>
        public static List<PPIJboardMessage> GetLastMessages(string token, int count)
        {
            PPIJboardServiceSoapClient client = new PPIJboardServiceSoapClient();
            return client.GetLastMessages(token, count);
        }

        /// <summary>
        /// Dohvaća poruke na PPIJboardu u prikladnom formatu. Ukoliko je token istekao ili krivi, baca TokenNotValidException.
        /// </summary>
        /// <param name="token">Pristupni token</param>
        /// <returns>Poruke sa PPIJboarda</returns>
        public static List<PPIJboardMessage> GetMessages(string token)
        {
            PPIJboardServiceSoapClient client = new PPIJboardServiceSoapClient();
            return client.GetMessages(token);
        }

        /// <summary>
        /// Stavlja novu poruku na PPIJboard. Ukoliko je token istekao ili krivi, baca TokenNotValidException, a ukoliko su podaci krivi baca DataNotValidException.
        /// </summary>
        /// <param name="token">Pristupni token</param>
        /// <param name="author">Autor poruke</param>
        /// <param name="message">Sadržaj poruke</param>
        public static void PostMessage(string token, string author, string message)
        {
            try
            {
                PPIJboardServiceSoapClient client = new PPIJboardServiceSoapClient();
                client.PostMessage(token, author, message);
            }
            catch
            {
                Console.WriteLine("DataNotValidException nevaljaju podaci");
            }
        }

        /// <summary>
        /// Stavlja novi odgovor na poruke na PPIJboard. Ukoliko je token istekao ili krivi, baca TokenNotValidException, a ukoliko su podaci krivi baca DataNotValidException.
        /// </summary>
        /// <param name="token">Pristupni token</param>
        /// <param name="author">Autor poruke</param>
        /// <param name="message">Sadržaj poruke</param>
        /// <param name="replyTo">ID poruke na koju se odgovara</param>
        public static void PostReply(string token, string author, string message, int? replyTo)
        {
            try
            {
                PPIJboardServiceSoapClient client = new PPIJboardServiceSoapClient();
                client.PostReply(token, author, message, replyTo);
            }
            catch (Exception replayexception)
            {
                if (replayexception.Message.Contains(""))
                {
                    Console.WriteLine("ReplayExeption nema poruke pod tim brojem");   
                }
            }
        }
    }
}
