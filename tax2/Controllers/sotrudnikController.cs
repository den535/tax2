using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tax2.Controllers
{
    public class sotrudnikController : Controller
    {
        private tax2Entities db = new tax2Entities();

        //
        // GET: /sotrudnik/

        public ActionResult Index()
        {
            return View(db.sotrudnik.ToList());
        }

        //
        // GET: /sotrudnik/Details/5

        public ActionResult Details(int id = 0)
        {
            sotrudnik sotrudnik = db.sotrudnik.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        //
        // GET: /sotrudnik/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /sotrudnik/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.sotrudnik.Add(sotrudnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sotrudnik);
        }

        //
        // GET: /sotrudnik/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sotrudnik sotrudnik = db.sotrudnik.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        //
        // POST: /sotrudnik/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sotrudnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sotrudnik);
        }

        //
        // GET: /sotrudnik/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sotrudnik sotrudnik = db.sotrudnik.Find(id);
            if (sotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(sotrudnik);
        }

        //
        // POST: /sotrudnik/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sotrudnik sotrudnik = db.sotrudnik.Find(id);
            db.sotrudnik.Remove(sotrudnik);
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