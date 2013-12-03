using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tax2.Controllers
{
    public class vizovController : Controller
    {
        private tax2Entities db = new tax2Entities();

        //
        // GET: /vizov/

        public ActionResult Index()
        {
            var vizov = db.vizov.Include(v => v.tip_vizova).Include(v => v.zakaz);
            return View(vizov.ToList());
        }

        //
        // GET: /vizov/Details/5

        public ActionResult Details(int id = 0)
        {
            vizov vizov = db.vizov.Find(id);
            if (vizov == null)
            {
                return HttpNotFound();
            }
            return View(vizov);
        }

        //
        // GET: /vizov/Create

        public ActionResult Create()
        {
            ViewBag.id_tip_vizova = new SelectList(db.tip_vizova, "id", "name");
            ViewBag.id_zakaza = new SelectList(db.zakaz, "id", "A");
            ViewBag.id_sotrudnika = new SelectList(db.sotrudnik, "id", "last_name");
            return View();
        }

        //
        // POST: /vizov/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vizov vizov)
        {
            if (ModelState.IsValid)
            {
                db.vizov.Add(vizov);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tip_vizova = new SelectList(db.tip_vizova, "id", "name", vizov.id_tip_vizova);
            ViewBag.id_zakaza = new SelectList(db.zakaz, "id", "A", vizov.id_zakaza);
            return View(vizov);
        }

        //
        // GET: /vizov/Edit/5

        public ActionResult Edit(int id = 0)
        {
            vizov vizov = db.vizov.Find(id);
            if (vizov == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tip_vizova = new SelectList(db.tip_vizova, "id", "name", vizov.id_tip_vizova);
            ViewBag.id_zakaza = new SelectList(db.zakaz, "id", "A", vizov.id_zakaza);
            return View(vizov);
        }

        //
        // POST: /vizov/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vizov vizov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vizov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tip_vizova = new SelectList(db.tip_vizova, "id", "name", vizov.id_tip_vizova);
            ViewBag.id_zakaza = new SelectList(db.zakaz, "id", "A", vizov.id_zakaza);
            return View(vizov);
        }

        //
        // GET: /vizov/Delete/5

        public ActionResult Delete(int id = 0)
        {
            vizov vizov = db.vizov.Find(id);
            if (vizov == null)
            {
                return HttpNotFound();
            }
            return View(vizov);
        }

        //
        // POST: /vizov/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vizov vizov = db.vizov.Find(id);
            db.vizov.Remove(vizov);
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