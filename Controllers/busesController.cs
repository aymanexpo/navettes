using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using navettes.Models;

namespace navettes.Controllers
{
    public class busesController : Controller
    {
        private navetteEntities1 db = new navetteEntities1();

        // GET: buses
        public ActionResult Index()
        {
            var bus = db.bus.Include(b => b.Ste);
            return View(bus.ToList());
        }

        // GET: buses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.bus.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: buses/Create
        public ActionResult Create()
        {
            ViewBag.idSte = new SelectList(db.Ste, "id", "Nomste");
            return View();
        }

        // POST: buses/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,VehiculeDescr,NbreSiege,passwordste,idSte")] bus bus)
        {
            if (ModelState.IsValid)
            {
                db.bus.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSte = new SelectList(db.Ste, "id", "Nomste", bus.idSte);
            return View(bus);
        }

        // GET: buses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.bus.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSte = new SelectList(db.Ste, "id", "Nomste", bus.idSte);
            return View(bus);
        }

        // POST: buses/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,VehiculeDescr,NbreSiege,passwordste,idSte")] bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSte = new SelectList(db.Ste, "id", "Nomste", bus.idSte);
            return View(bus);
        }

        // GET: buses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.bus.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bus bus = db.bus.Find(id);
            db.bus.Remove(bus);
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
        public ActionResult busesCRUD()
        {
            return View(db.bus.ToList());
        }
    }
}
