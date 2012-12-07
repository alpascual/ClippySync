using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClippyWindowsClient
{
    [DataContract]
    public class SyncItem
    {   
        [DataMember]
        public int SyncID { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string ClipboardData { get; set; }
    }
}
