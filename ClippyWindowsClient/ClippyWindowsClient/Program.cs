using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClippyWindowsClient
{
    static class Program
    {
        static System.Windows.Forms.Timer _clipboardTimer;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _clipboardTimer = new Timer();
            _clipboardTimer.Interval = 1000 * 5;
            _clipboardTimer.Tick += _clipboardTimer_Tick;
            _clipboardTimer.Start();

            Application.Run(new Form1());

        }

        static double lastnumber;
        public static string _lastText = "";

        static void _clipboardTimer_Tick(object sender, EventArgs e)
        {
            if (CredentialsStorage.ClipboardRunning == true)
            {
                if (CredentialsStorage.Username != null)
                {
                    if (CredentialsStorage.Username.Length > 1)
                    {
                        //Check if there is something from Clipboard.
                        if (_lastText != CredentialsStorage.ClipboardData && CredentialsStorage.ClipboardData != null)
                        {
                            System.Windows.Forms.Clipboard.SetText(CredentialsStorage.ClipboardData);
                            _lastText = CredentialsStorage.ClipboardData;
                        }

                        //Check if nothing new is in the clipboard.
                        if (System.Windows.Forms.Clipboard.ContainsText())
                        {
                            string sTextOnClipboard = System.Windows.Forms.Clipboard.GetText();
                            if (sTextOnClipboard != _lastText)
                            {
                                // Send to server
                                ServerProtocol protocol = new ServerProtocol();
                                lastnumber = protocol.SendTextToClipboard(CredentialsStorage.Username, CredentialsStorage.Password, sTextOnClipboard);
                                if (lastnumber > 0)
                                {
                                    //if successful
                                    _lastText = sTextOnClipboard;
                                    CredentialsStorage.LastNumber = lastnumber;

                                    //TODO maybe some feedback to the user?
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
