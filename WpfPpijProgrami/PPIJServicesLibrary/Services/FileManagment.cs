using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PPIJServicesLibrary;

namespace PPIJServicesLibrary.Services
{
    public class FileManagment
    {
        public void SaveAccessTokenppijToFile(string accessToken)
        {
            FileStream savetokenatofile = new FileStream(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokenppij.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter savetokentofilestream = new StreamWriter(savetokenatofile);
            savetokentofilestream.WriteLine(accessToken);
            savetokentofilestream.Close();
            savetokenatofile.Close();
        }
        public string ReadAccessTokenppijFromFile()
        {
            FileStream readfromfiletoken = new FileStream(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokenppij.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader streamreadertoken = new StreamReader(readfromfiletoken);
            string token = streamreadertoken.ReadLine();
            streamreadertoken.Close();
            readfromfiletoken.Close();
            return token;
        }
        public void SaveAccessTokenTwitterToFile(string accessToken, string accessTokenSecret)
        {
            FileStream savetokenatofile = new FileStream(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokentwitter.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter savetokentofilestream = new StreamWriter(savetokenatofile);
            savetokentofilestream.WriteLine(accessToken);
            savetokentofilestream.Close();
            savetokenatofile.Close();
            FileStream savetokeSecretnatofile = new FileStream(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokensecrettwitter.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter savetokenSecrettofilestream = new StreamWriter(savetokeSecretnatofile);
            savetokenSecrettofilestream.WriteLine(accessTokenSecret);
            savetokenSecrettofilestream.Close();
            savetokeSecretnatofile.Close();
        }
        public string[] ReadAccessTokenTwitterFromFile()
        {
            int numberOfAccessToken = 2;
            int accessTokenNum = 0;
            int accessTokenSecretNum = 1;

            FileStream readfromfiletoken = new FileStream(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokentwitter.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader streamreadertoken = new StreamReader(readfromfiletoken);
            string[] token = new string[numberOfAccessToken];
            token[accessTokenNum] = streamreadertoken.ReadLine();
            streamreadertoken.Close();
            readfromfiletoken.Close();
            FileStream readfromfiletokenSecret = new FileStream(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokensecrettwitter.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader streamreadertokenSecret = new StreamReader(readfromfiletokenSecret);
            token[accessTokenSecretNum] = streamreadertokenSecret.ReadLine();
            streamreadertokenSecret.Close();
            readfromfiletokenSecret.Close();
            return token;
        }
        public void EraseFile()
        {
            File.Delete(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokentwitter.txt");
            File.Delete(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokensecrettwitter.txt");
            File.Create(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokentwitter.txt");
            File.Create(@"C:\Users\Filip\Desktop\WpfPpijProgrami\PPIJServicesLibrary\Files\accesstokensecrettwitter.txt");
        }
    }
}
