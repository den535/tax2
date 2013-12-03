using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tax2.Controllers
{
    public class tcController : Controller
    {
        private tax2Entities db = new tax2Entities();

        //
        // GET: /tc/

        public ActionResult Index()
        {
            return View(db.tc.ToList());
        }

        //
        // GET: /tc/Details/5

        public ActionResult Details(int id = 0)
        {
            tc tc = db.tc.Find(id);
            if (tc == null)
            {
                return HttpNotFound();
            }
            return View(tc);
        }

        //
        // GET: /tc/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /tc/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tc tc)
        {
            if (ModelState.IsValid)
            {
                db.tc.Add(tc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tc);
        }

        //
        // GET: /tc/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tc tc = db.tc.Find(id);
            if (tc == null)
            {
                return HttpNotFound();
            }
            return View(tc);
        }

        //
        // POST: /tc/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tc tc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tc);
        }

        //
        // GET: /tc/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tc tc = db.tc.Find(id);
            if (tc == null)
            {
                return HttpNotFound();
            }
            return View(tc);
        }

        //
        // POST: /tc/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tc tc = db.tc.Find(id);
            db.tc.Remove(tc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}