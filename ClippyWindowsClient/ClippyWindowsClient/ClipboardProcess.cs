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
            if (_ThreadRunning == false)
            {
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

        public void ProcessClipboard()
        {
            while (_ThreadRunning == true)
            {
                if (System.Windows.Forms.Clipboard.ContainsText())
                {
                    string sTextOnClipboard = System.Windows.Forms.Clipboard.GetText();
                    if (sTextOnClipboard != _lastText)
                    {
                        // Send to server

                        //if successful
                        _lastText = sTextOnClipboard;
                    }                    
                }

                Thread.Sleep(1000 * 2);
            }
        }
    }
}
