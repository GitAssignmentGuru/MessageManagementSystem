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
    public class MessageInformationsController : Controller
    {
        private MMSEntities111 db = new MMSEntities111();

        // GET: MessageInformations
        public ActionResult Index()
        {
            var messageInformations = db.MessageInformations.Include(m => m.ClinetInformation);
            return View(messageInformations.ToList());
        }

        // GET: MessageInformations/Details/5
        public ActionResult Details(string ClientID)
        {
            if (ClientID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageInformation messageInformation = db.MessageInformations.Where(m=>m.ClientID == ClientID).FirstOrDefault();
            if (messageInformation == null)
            {
                return HttpNotFound();
            }
            return View(messageInformation);
        }

        // GET: MessageInformations/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.ClinetInformations, "UniqueID", "Name");
            return View();
        }

        // POST: MessageInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,Message,NumberOfdays,StartDate,CostofUnit,Status")] MessageInformation messageInformation)
        {
            if (ModelState.IsValid)
            {
                db.MessageInformations.Add(messageInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.ClinetInformations, "UniqueID", "Name", messageInformation.ClientID);
            return View(messageInformation);
        }

        // GET: MessageInformations/Edit/5
        public ActionResult Edit(string ClientID)
        {
            if (ClientID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageInformation messageInformation = db.MessageInformations.Where(m => m.ClientID == ClientID).FirstOrDefault();
            if (messageInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.ClinetInformations, "UniqueID", "Name", messageInformation.ClientID);
            return View(messageInformation);
        }

        // POST: MessageInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,Message,NumberOfdays,StartDate,CostofUnit,Status")] MessageInformation messageInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.ClinetInformations, "UniqueID", "Name", messageInformation.ClientID);
            return View(messageInformation);
        }

        // GET: MessageInformations/Delete/5
        public ActionResult Delete(string ClientID)
        {
            if (ClientID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageInformation messageInformation = db.MessageInformations.Where(m => m.ClientID == ClientID).FirstOrDefault();
            if (messageInformation == null)
            {
                return HttpNotFound();
            }
            return View(messageInformation);
        }

        // POST: MessageInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MessageInformation messageInformation = db.MessageInformations.Find(id);
            db.MessageInformations.Remove(messageInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
