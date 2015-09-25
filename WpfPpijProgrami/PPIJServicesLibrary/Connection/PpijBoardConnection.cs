using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPIJServicesLibrary.Data;
using PPIJServicesLibrary.Services;
using System.IO;
using PPIJServicesLibrary.PPIJBoard;

namespace PPIJServicesLibrary.Connection
{
    public class PpijBoardConnection : IInterface
    {
        
        private PPIJservicetokens ppijtokeni = new PPIJservicetokens();
        private FileManagment writeAccessTokenToFile = new FileManagment();
        private PpijBoadrData ppijmessagedata = new PpijBoadrData();
        private DateTime startTime;
        private DateTime stopTime;
        private TimeSpan elapsedTime;

        public PpijBoardConnection()
        {
            LoadTokens();
        }
        public void LoadTokens()
        {
            startTime = DateTime.Now;
            TextReader readKeyFromFile = new StreamReader(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\appkljuc.txt");
            ppijtokeni.Appkeyppij = readKeyFromFile.ReadLine();
            ppijtokeni.AccessTokenppij = PPIJBoardService.GetAccessToken(ppijtokeni.Appkeyppij);
            writeAccessTokenToFile.SaveAccessTokenppijToFile(ppijtokeni.AccessTokenppij);
        }

        public void loadPpijToken(string imeAutora, string poruka)
        {
            ppijmessagedata.Message = poruka;
            ppijmessagedata.NameAutor = imeAutora;
            ppijmessagedata.IsAnswer = false;
        }
        public void loadPpijToken(string imeAutora, string poruka, string odogovornaPoruku)
        {
            ppijmessagedata.IsAnswer = true;
            ppijmessagedata.Message = poruka;
            ppijmessagedata.NameAutor = imeAutora;
            ppijmessagedata.Replaynumber = odogovornaPoruku;
        }
        public void Send()
        {
            
            if (ppijmessagedata.Replaynumber != null)
            {
                PPIJBoardService.PostReply(ppijtokeni.AccessTokenppij, ppijmessagedata.NameAutor, ppijmessagedata.Message, Convert.ToInt32(ppijmessagedata.Replaynumber));
            }
            else
            {
                PPIJBoardService.PostMessage(ppijtokeni.AccessTokenppij, ppijmessagedata.NameAutor, ppijmessagedata.Message);
            }
         }

        public void SetTokens()
        {
            stopTime = DateTime.Now;
            elapsedTime = stopTime - startTime;
            int accessTokenExpiringMinutes = 5;

            if (elapsedTime.Minutes >= accessTokenExpiringMinutes)
            {
                LoadTokens();
            }
        }

        public List<PpijBoardFriends> GetPpijBoardFriends()
        {
            List<PPIJboardMessage> messageList = PPIJBoardService.GetLastMessages(ppijtokeni.AccessTokenppij, 100);
            List<PpijBoardFriends> ppijBoardFriends = new List<PpijBoardFriends>();

            //LINQ
            IEnumerable<PpijBoardFriends> friends = from friend in messageList
                                                    orderby friend.Author
                                                    select new PpijBoardFriends { Name = friend.Author, Id = friend.Id.ToString(), Poruka = friend.Text, Time = friend.Posted.ToString()};


            foreach (var item in friends)
            {
                List<string> list = new List<string>();

                foreach (var item2 in friends)
                {
                    if (item.Name == item2.Name)
                    {
                        list.Add(item2.Poruka);
                    }
                }

                item.Poruke = list;

                if (ppijBoardFriends.Count == 0)
                {
                    ppijBoardFriends.Add(item);
                }
                else
                {
                    bool isAdded = true;
                    foreach (var item3 in ppijBoardFriends)
                    {
                        if (item3.Name == item.Name)
                        {
                            isAdded = false;
                            break;
                        }
                    }
                    if (isAdded)
                    {
                        ppijBoardFriends.Add(item);
                    }
                }
            }

            return ppijBoardFriends;
        }
    }
}
