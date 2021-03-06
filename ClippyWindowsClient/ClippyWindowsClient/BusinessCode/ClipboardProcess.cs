﻿using System;
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
        Thread tServer;
        

        public void Start()
        {
            tServer = new Thread(ProcessMethod);
            
            if (_ThreadRunning == false)
            {
                CredentialsStorage.ClipboardRunning = _ThreadRunning = true;
                tServer.Start();                
            }
        }

        public void Stop()
        {
            if (_ThreadRunning == true)
            {
                tServer.Abort();
                tServer = null;
            }

            CredentialsStorage.ClipboardRunning = _ThreadRunning = false;
        }

        public void ProcessMethod()
        {
            ServerProtocol protocol = new ServerProtocol();
            while (_ThreadRunning == true)
            {
                if (CredentialsStorage.Username != null)
                {
                    if (CredentialsStorage.Username.Length > 1)
                    {
                        // Check on the server
                        string clipBoardText = protocol.GetTextFromClipboard(CredentialsStorage.Username, CredentialsStorage.Password, CredentialsStorage.LastNumber);
                        try
                        {
                            SyncItem item = JSONHelper.Deserialize<SyncItem>(clipBoardText);

                            CredentialsStorage.LastNumber = item.SyncID;
                            CredentialsStorage.ClipboardData = item.ClipboardData;
                        }
                        catch { }
                        
                    }
                }

                Thread.Sleep(1000 * 2);
            }
        }

        
    }
}
