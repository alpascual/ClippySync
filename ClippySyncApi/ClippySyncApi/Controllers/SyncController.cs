using ClippySyncApi.Code;
using ClippySyncApi.Models;
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

        public JsonResult SendClipboard(string Username, string Password, string Clipboard, int version)
        {
            if (WebSecurity.Login(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)) == true)
            {
                int UserId = WebSecurity.GetUserId(Encrypter.base64Decode(Username));

                // Business Logic to add the content on the database
                SyncModel sync = new SyncModel();
                SyncUser myUser = new SyncUser()
                {
                    UserId = UserId,
                    ClipboardData = Encrypter.base64Decode(Clipboard)
                };

                sync.SyncUsers.Add(myUser);
                sync.SaveChanges();

                return Json(myUser.SyncID, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);            
        }

        public JsonResult GetClipboard(string Username, string Password, int SequenceNumber, int version)
        {
            if (WebSecurity.Login(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)) == true)
            {
                int UserId = WebSecurity.GetUserId(Encrypter.base64Decode(Username));

                // Business Logic to get the clipboard if any or hold the socket open
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
                        SyncUser userClipboard = checkIfAny[0];
                        return Json(userClipboard, JsonRequestBehavior.AllowGet);
                    }

                    // Hold the socket
                    System.Threading.Thread.Sleep(1000 * 10);
                    timeout++;
                }
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        
    }
}
