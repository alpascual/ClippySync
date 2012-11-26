using ClippySyncApi.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

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

        public JsonResult SendClipboard(string Username, string Password, string Clipboard)
        {
            if (WebSecurity.Login(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)) == true)
            {
                int UserId = WebSecurity.GetUserId(Encrypter.base64Decode(Username));

                // Business Logic to add the content on the database
            }
            return Json(0, JsonRequestBehavior.AllowGet);            
        }

        public JsonResult GetClipboard(string Username, string Password, int SequenceNumber)
        {
            if (WebSecurity.Login(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)) == true)
            {
                int UserId = WebSecurity.GetUserId(Encrypter.base64Decode(Username));

                // Business Logic to get the clipboard if any or hold the socket open
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        
    }
}
