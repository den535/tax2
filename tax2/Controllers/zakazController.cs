using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tax2.Controllers
{
    public class zakazController : Controller
    {
        private tax2Entities db = new tax2Entities();

        //
        // GET: /zakaz/

        public ActionResult Index()
        {
            var zakaz = db.zakaz.Include(z => z.sotrudnik).Include(z => z.tc);
            return View(zakaz.ToList());
        }

        //
        // GET: /zakaz/Details/5

        public ActionResult Details(int id = 0)
        {
            zakaz zakaz = db.zakaz.Find(id);
            if (zakaz == null)
            {
                return HttpNotFound();
            }
            return View(zakaz);
        }

        //
        // GET: /zakaz/Create

        public ActionResult Create()
        {
            ViewBag.id_sotrudnika = new SelectList(db.sotrudnik, "id", "first_name");
            ViewBag.id_TC = new SelectList(db.tc, "id", "marka");
            return View();
        }

        //
        // POST: /zakaz/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(zakaz zakaz)
        {
            if (ModelState.IsValid)
            {
                db.zakaz.Add(zakaz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_sotrudnika = new SelectList(db.sotrudnik, "id", "first_name", zakaz.id_sotrudnika);
            ViewBag.id_TC = new SelectList(db.tc, "id", "color", zakaz.id_TC);
            return View(zakaz);
        }

        //
        // GET: /zakaz/Edit/5

        public ActionResult Edit(int id = 0)
        {
            zakaz zakaz = db.zakaz.Find(id);
            if (zakaz == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sotrudnika = new SelectList(db.sotrudnik, "id", "first_name", zakaz.id_sotrudnika);
            ViewBag.id_TC = new SelectList(db.tc, "id", "color", zakaz.id_TC);
            return View(zakaz);
        }

        //
        // POST: /zakaz/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(zakaz zakaz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakaz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_sotrudnika = new SelectList(db.sotrudnik, "id", "first_name", zakaz.id_sotrudnika);
            ViewBag.id_TC = new SelectList(db.tc, "id", "color", zakaz.id_TC);
            return View(zakaz);
        }

        //
        // GET: /zakaz/Delete/5

        public ActionResult Delete(int id = 0)
        {
            zakaz zakaz = db.zakaz.Find(id);
            if (zakaz == null)
            {
                return HttpNotFound();
            }
            return View(zakaz);
        }

        //
        // POST: /zakaz/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zakaz zakaz = db.zakaz.Find(id);
            db.zakaz.Remove(zakaz);
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