using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using ClippySyncServer.Filters;
using ClippySyncServer.Models;
using ClippySyncServer.Code;
namespace ClippySyncServer.Controllers
{
    [InitializeSimpleMembership]
    public class SyncController : Controller
    {
        //
        // GET: /Sync/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Register(string Username, string Password, int version)
        {
            try
            {
                return Json(WebSecurity.CreateUserAndAccount(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)),
                    JsonRequestBehavior.AllowGet);
            }
            catch (MembershipCreateUserException e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Login(string Username, string Password, int version)
        {
            return Json(WebSecurity.Login(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendClipboard(string Username, string Password, string Clipboard, int version)
        {
            if (WebSecurity.Login(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)) == true)
            {
                int UserId = WebSecurity.GetUserId(Encrypter.base64Decode(Username));

                // Can I decode?
                string cleanClipboard = "";
                try
                {
                    cleanClipboard = Encrypter.base64Decode(Clipboard);
                }
                catch
                {
                    return Json(-1, JsonRequestBehavior.AllowGet);
                }
                // Business Logic to add the content on the database
                SyncModel sync = new SyncModel();
                SyncUser myUser = new SyncUser()
                {
                    UserId = UserId,
                    ClipboardData = cleanClipboard
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
                        SyncUser userClipboard = checkIfAny[checkIfAny.Count-1];
                        return Json(userClipboard, JsonRequestBehavior.AllowGet);
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

            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}
