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
                //todo confirm account
                //WebSecurity.ConfirmAccount(
                
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

                int SyncID = DatabaseClipBoard.SendClipboard(UserId, cleanClipboard);

                return Json(SyncID, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClipboard(string Username, string Password, int SequenceNumber, int version)
        {
            if (WebSecurity.Login(Encrypter.base64Decode(Username), Encrypter.base64Decode(Password)) == true)
            {
                int UserId = WebSecurity.GetUserId(Encrypter.base64Decode(Username));

                // Business Logic to get the clipboard if any or hold the socket open
                SyncUser userClipboard = DatabaseClipBoard.GetClipboard(UserId, SequenceNumber);
                if ( userClipboard != null )
                    return Json(userClipboard, JsonRequestBehavior.AllowGet);

            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}
