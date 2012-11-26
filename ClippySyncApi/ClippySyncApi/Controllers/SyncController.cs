using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClippySyncApi.Controllers
{
    public class SyncController : Controller
    {
        //
        // GET: /Sync/

        public ActionResult Index()
        {
            return View();
        }

        public int SendClipboard(string UserToken, string Clipboard)
        {

            return 0;
        }

        public string GetClipboard(string UserToken, int SequenceNumber)
        {
            return "";
        }

    }
}
