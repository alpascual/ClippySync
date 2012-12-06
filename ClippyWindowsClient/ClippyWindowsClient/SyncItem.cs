using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClippyWindowsClient
{
    [Serializable]
    public class SyncItem
    {   
        public int SyncID { get; set; }
        public int UserId { get; set; }
        public string ClipboardData { get; set; }
    }
}
