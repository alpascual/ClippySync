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

        public void Start()
        {
            Thread t1 = new Thread(ProcessMethod);
            if (_ThreadRunning == false)
            {
                _ThreadRunning = true;
                t1.Start();
            }
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

                Thread.Sleep(1000 * 5);
            }
        }
    }
}
