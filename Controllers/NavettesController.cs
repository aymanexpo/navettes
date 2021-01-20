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
    public class NavettesController : Controller
    {
        private navetteEntities1 db = new navetteEntities1();

        // GET: Navettes
        public ActionResult Index()
        {
            var navette = db.Navette.Include(n => n.bus);
            return View(navette.ToList());
        }

        // GET: Navettes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navette navette = db.Navette.Find(id);
            if (navette == null)
            {
                return HttpNotFound();
            }
            return View(navette);
        }

        // GET: Navettes/Create
        public ActionResult Create()
        {
            ViewBag.idbus = new SelectList(db.bus, "id", "VehiculeDescr");
            return View();
        }

        // POST: Navettes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fromCity,toCity,timeGo,timeWent,idbus")] Navette navette)
        {
            if (ModelState.IsValid)
            {
                db.Navette.Add(navette);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idbus = new SelectList(db.bus, "id", "VehiculeDescr", navette.idbus);
            return View(navette);
        }

        // GET: Navettes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navette navette = db.Navette.Find(id);
            if (navette == null)
            {
                return HttpNotFound();
            }
            ViewBag.idbus = new SelectList(db.bus, "id", "VehiculeDescr", navette.idbus);
            return View(navette);
        }

        // POST: Navettes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fromCity,toCity,timeGo,timeWent,idbus")] Navette navette)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navette).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idbus = new SelectList(db.bus, "id", "VehiculeDescr", navette.idbus);
            return View(navette);
        }

        // GET: Navettes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navette navette = db.Navette.Find(id);
            if (navette == null)
            {
                return HttpNotFound();
            }
            return View(navette);
        }

        // POST: Navettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Navette navette = db.Navette.Find(id);
            db.Navette.Remove(navette);
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
        public ActionResult NavettesCRUD()
        {
            return View(db.Navette.ToList());
        }
    }
}
