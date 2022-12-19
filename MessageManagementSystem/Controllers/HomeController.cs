using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MessageManagementSystem.Models;

namespace MessageManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private MMSEntities111 db = new MMSEntities111();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            if(Username == "admin" && Password == "123456")
            {
                Session["Login"] = "login";
                return RedirectToAction("/HomePage");
            }
            TempData["message"] = "Incorrect Username Password.";
            return View();
        }
        public ActionResult HomePage()
        {
            ViewBag.ClientID = new SelectList(db.ClinetInformations, "UniqueID", "Name");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session["Login"] = null;
            return RedirectToAction("/Index");
        }

        [HttpPost]
        public ActionResult GetDefault(string val)
        {
            if (val != null)
            {
                var message = "No message set for this client till now.";
                var info = db.MessageInformations.Where(m => m.ClientID == val);
                if (info.Any())
                {
                    message = info.FirstOrDefault().Message;
                }
                return Json(new { Success = "true", Data = new { info = message } });
            }
            return Json(new { Success = "false" });
        }
    }
}