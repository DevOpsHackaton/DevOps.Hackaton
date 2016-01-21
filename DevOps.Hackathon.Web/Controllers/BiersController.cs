using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevOps.Hackathon.Web.Data;
using DevOps.Hackathon.Web.Models;

namespace DevOps.Hackathon.Web.Controllers
{
    public class BiersController : Controller
    {
        private BierDb db = new BierDb();

        // GET: Biers
        public ActionResult Index()
        {
            return View(db.Biers.ToList());
        }

        // GET: Biers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bier bier = db.Biers.Find(id);
            if (bier == null)
            {
                return HttpNotFound();
            }
            return View(bier);
        }

        // GET: Biers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Biers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Bier bier)
        {
            if (ModelState.IsValid)
            {
                db.Biers.Add(bier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bier);
        }

        // GET: Biers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bier bier = db.Biers.Find(id);
            if (bier == null)
            {
                return HttpNotFound();
            }
            return View(bier);
        }

        // POST: Biers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Bier bier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bier);
        }

        // GET: Biers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bier bier = db.Biers.Find(id);
            if (bier == null)
            {
                return HttpNotFound();
            }
            return View(bier);
        }

        // POST: Biers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bier bier = db.Biers.Find(id);
            db.Biers.Remove(bier);
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
