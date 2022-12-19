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
    public class ClientInformationsController : Controller
    {
        private MMSEntities111 db = new MMSEntities111();

        // GET: ClientInformations
        public ActionResult Index()
        {
            return View(db.ClinetInformations.ToList());
        }

        // GET: ClientInformations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClinetInformation clinetInformation = db.ClinetInformations.Find(id);
            if (clinetInformation == null)
            {
                return HttpNotFound();
            }
            return View(clinetInformation);
        }

        // GET: ClientInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniqueID,Name,Address,PhoneNumber,CreditUnits")] ClinetInformation clinetInformation)
        {
            Random rng = new Random();
            int value = rng.Next(1000);
            string text = value.ToString("000");
            clinetInformation.UniqueID = clinetInformation.Name + text;
            db.ClinetInformations.Add(clinetInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ClientInformations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClinetInformation clinetInformation = db.ClinetInformations.Find(id);
            if (clinetInformation == null)
            {
                return HttpNotFound();
            }
            return View(clinetInformation);
        }

        // POST: ClientInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniqueID,Name,Address,PhoneNumber,CreditUnits")] ClinetInformation clinetInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinetInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinetInformation);
        }

        // GET: ClientInformations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClinetInformation clinetInformation = db.ClinetInformations.Find(id);
            if (clinetInformation == null)
            {
                return HttpNotFound();
            }
            return View(clinetInformation);
        }

        // POST: ClientInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ClinetInformation clinetInformation = db.ClinetInformations.Find(id);
            db.ClinetInformations.Remove(clinetInformation);
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
