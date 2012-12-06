using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClippyWindowsClient
{
    public class ClipboardProcess
    {

        private bool _ThreadRunning = false;
        double lastnumber;
        Thread tClipboard;
        Thread tServer;
        string _lastText = "";

        public void Start()
        {
            tServer = new Thread(ProcessMethod);
            tClipboard = new Thread(ProcessClipboard);
            tClipboard.IsBackground = false;
            tClipboard.Priority = ThreadPriority.Highest;
            
            if (_ThreadRunning == false)
            {
                System.Windows.Forms.Clipboard.Clear();

                _ThreadRunning = true;
                tServer.Start();
                tClipboard.Start();
            }
        }

        public void Stop()
        {
            tServer.Abort();
            tServer = null;
            tClipboard.Abort();
            tClipboard = null;
            _ThreadRunning = false;
        }

        public void ProcessMethod()
        {
            while (_ThreadRunning == true)
            {
                if (CredentialsStorage.Username != null)
                {
                    if (CredentialsStorage.Username.Length > 1)
                    {
                        // Check on the server
                    }
                }

                Thread.Sleep(1000 * 2);
            }
        }

        [STAThread]
        public void ProcessClipboard()
        {
            while (_ThreadRunning == true)
            {
                if (CredentialsStorage.Username != null)
                {
                    if (CredentialsStorage.Username.Length > 1)
                    {
                        
                        if (System.Windows.Forms.Clipboard.ContainsText())
                        {
                            string sTextOnClipboard = System.Windows.Forms.Clipboard.GetText();
                            if (sTextOnClipboard != _lastText)
                            {
                                // Send to server
                                ServerProtocol protocol = new ServerProtocol();
                                protocol.SendTextToClipboard(CredentialsStorage.Username, CredentialsStorage.Password, sTextOnClipboard);

                                //if successful
                                _lastText = sTextOnClipboard;
                            }
                        }

                        if (System.Windows.Forms.Clipboard.GetDataObject() != null)
                        {

                        }
                    }
                }

                Thread.Sleep(1000 * 2);
            }
        }
    }
}
