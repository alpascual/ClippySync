using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippyWindowsClient
{
    public static class CredentialsStorage
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static double LastNumber { get; set; }
        public static string ClipboardData { get; set; }
        public static bool ClipboardRunning { get; set; }

    }

   
}
