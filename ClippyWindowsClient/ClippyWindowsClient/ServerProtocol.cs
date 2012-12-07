using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClippyWindowsClient
{
    public class ServerProtocol
    {
        public bool ServerLogin(string Username, string Password)
        {
             string sResponse = RequestToServer("Login?username=" + Encrypter.base64Encode(Username) + "&Password=" + Encrypter.base64Encode(Password) + "&Version=1");

            return true;
        }

        public double SendTextToClipboard(string Username, string Password, string sClipboard)
        {
            string sRequestString = "SendClipboard?username=" + Encrypter.base64Encode(Username) + "&Password=" + Encrypter.base64Encode(Password) + "&Clipboard=" + Encrypter.base64Encode(sClipboard) + "&Version=1";
            string sResponse = RequestToServer(sRequestString);

            double SyncID = 0;
            try
            {
                Console.WriteLine("DEBUG: response: " + sResponse);
                SyncID = Convert.ToDouble(sResponse);
            }
            catch
            {
                SyncID = -1;
            }

            return SyncID;
        }

        public string GetTextFromClipboard(string Username, string Password, double SequenceNumber)
        {
            string sRequestString = "GetClipboard?username=" + Encrypter.base64Encode(Username) + "&Password=" + Encrypter.base64Encode(Password) +
                                    "&SequenceNumber=" + SequenceNumber + "&version=1";

            // Timeouts happen
            string sResponse = "";
            try
            {
                 sResponse = RequestToServer(sRequestString);
            }
            catch { }
           

            return sResponse;
        }

        public string RegistrationUrl()
        {
            return Server.Url.Replace("sync/", "Account/Register");
        }

        private string RequestToServer(string sUrlRequest)
        {
            string sUrl = Server.Url + sUrlRequest;

            WebClient client = new WebClient();
            return client.DownloadString(sUrl);
        }
    }

    public static class Server
    {
        public static string Url
        {
            //get { return "http://localhost:17905/sync/"; }
            get { return "http://clippy.azurewebsites.net/sync/"; }
        }

    }
}
