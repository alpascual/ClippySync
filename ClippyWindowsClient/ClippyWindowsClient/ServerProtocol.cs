using System;
using System.Collections.Generic;
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

        public string RegistrationUrl()
        {
            return Server.Url.Replace("sync/", ")
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
            get { return "http://localhost:1582/sync/"; }
        }

    }
}
