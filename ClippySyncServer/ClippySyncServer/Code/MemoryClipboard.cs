using ClippySyncServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClippySyncServer.Code
{
    public class MemoryClipboard
    {
    }

    public class DatabaseClipBoard
    {
        public static int SendClipboard(int UserId, string cleanClipboard)
        {
            // Business Logic to add the content on the database
            SyncModel sync = new SyncModel();
            SyncUser myUser = new SyncUser()
            {
                UserId = UserId,
                ClipboardData = cleanClipboard
            };

            sync.SyncUsers.Add(myUser);
            sync.SaveChanges();

            return myUser.UserId;
        }

        public static SyncUser GetClipboard(int UserId, int SequenceNumber)
        {
            SyncModel sync = new SyncModel();
            int timeout = 0;
            while (timeout < 100)
            {
                var checkIfAny = (from c in sync.SyncUsers
                                  where c.UserId == UserId &
                                  c.SyncID > SequenceNumber
                                  select c).ToList();

                if (checkIfAny.Count > 0)
                {
                    SyncUser userClipboard = checkIfAny[checkIfAny.Count - 1];
                    return userClipboard;
                    
                }

                // Hold the socket
                System.Threading.Thread.Sleep(1000 * 10);
                timeout++;
            }

            // delete old stuff from the users
            var toDelete = (from c in sync.SyncUsers
                            where c.UserId == UserId &
                            c.SyncID < SequenceNumber - 1
                            select c).ToList();
            for (int i = 0; i < toDelete.Count; i++)
                sync.SyncUsers.Remove(toDelete[i]);

            sync.SaveChanges();

            return null;
        }
    }
}