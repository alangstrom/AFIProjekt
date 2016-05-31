using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AFIProjekt.Models;

namespace AFIProjekt.Controllers
{
    public class MatchesController : Controller
    {
        private AFIProjektEntities db = new AFIProjektEntities();

        // GET: Matches
        public ActionResult Index()
        {
            return View(db.Matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Matches.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name1,Name2,Match")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(matches);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matches);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Matches.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name1,Name2,Match")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matches).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matches);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Matches.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matches matches = db.Matches.Find(id);
            db.Matches.Remove(matches);
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
