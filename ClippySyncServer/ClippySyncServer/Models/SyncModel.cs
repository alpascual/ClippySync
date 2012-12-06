using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace ClippySyncServer.Models
{
    public class SyncModel : DbContext
    {
        public SyncModel()
            : base("DefaultConnection")
        {
        }

        public DbSet<SyncUser> SyncUsers { get; set; }
    }

    [Table("SyncUser")]
    public class SyncUser
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SyncID { get; set; }
        public int UserId { get; set; }
        public string ClipboardData { get; set; }
    }
}