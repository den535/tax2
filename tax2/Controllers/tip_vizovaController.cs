using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tax2.Controllers
{
    public class tip_vizovaController : Controller
    {
        private tax2Entities db = new tax2Entities();

        //
        // GET: /tip_vizova/

        public ActionResult Index()
        {
            return View(db.tip_vizova.ToList());
        }

        //
        // GET: /tip_vizova/Details/5

        public ActionResult Details(int id = 0)
        {
            tip_vizova tip_vizova = db.tip_vizova.Find(id);
            if (tip_vizova == null)
            {
                return HttpNotFound();
            }
            return View(tip_vizova);
        }

        //
        // GET: /tip_vizova/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /tip_vizova/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tip_vizova tip_vizova)
        {
            if (ModelState.IsValid)
            {
                db.tip_vizova.Add(tip_vizova);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tip_vizova);
        }

        //
        // GET: /tip_vizova/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tip_vizova tip_vizova = db.tip_vizova.Find(id);
            if (tip_vizova == null)
            {
                return HttpNotFound();
            }
            return View(tip_vizova);
        }

        //
        // POST: /tip_vizova/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tip_vizova tip_vizova)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tip_vizova).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tip_vizova);
        }

        //
        // GET: /tip_vizova/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tip_vizova tip_vizova = db.tip_vizova.Find(id);
            if (tip_vizova == null)
            {
                return HttpNotFound();
            }
            return View(tip_vizova);
        }

        //
        // POST: /tip_vizova/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tip_vizova tip_vizova = db.tip_vizova.Find(id);
            db.tip_vizova.Remove(tip_vizova);
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