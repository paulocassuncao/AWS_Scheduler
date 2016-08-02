using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AWS_Scheduler.Models;

namespace AWS_Scheduler.Controllers
{
    public class CredentialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Credentials
        public ActionResult Index()
        {
            return View(db.Credentials.ToList());
        }

        // GET: Credentials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credentials credentials = db.Credentials.Find(id);
            if (credentials == null)
            {
                return HttpNotFound();
            }
            return View(credentials);
        }

        // GET: Credentials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Credentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CredentialsName,AccessKeyId,SecretAccessKey")] Credentials credentials)
        {
            if (ModelState.IsValid)
            {
                db.Credentials.Add(credentials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credentials);
        }

        // GET: Credentials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credentials credentials = db.Credentials.Find(id);
            if (credentials == null)
            {
                return HttpNotFound();
            }
            return View(credentials);
        }

        // POST: Credentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CredentialsName,AccessKeyId,SecretAccessKey")] Credentials credentials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credentials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credentials);
        }

        // GET: Credentials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credentials credentials = db.Credentials.Find(id);
            if (credentials == null)
            {
                return HttpNotFound();
            }
            return View(credentials);
        }

        // POST: Credentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Credentials credentials = db.Credentials.Find(id);
            db.Credentials.Remove(credentials);
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
