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
        
        Thread tServer;
        string _lastText = "";

        public void Start()
        {
            tServer = new Thread(ProcessMethod);
        
            
            if (_ThreadRunning == false)
            {
                System.Windows.Forms.Clipboard.Clear();

                _ThreadRunning = true;
                tServer.Start();
                
            }
        }

        public void Stop()
        {
            tServer.Abort();
            tServer = null;
          
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

        
    }
}
