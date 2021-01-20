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
    public class OffresController : Controller
    {
        private navetteEntities1 db = new navetteEntities1();

        // GET: Offres
        public ActionResult Index()
        {
            var offre = db.Offre.Include(o => o.Navette);
            return View(offre.ToList());
        }

        // GET: Offres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offre.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            ViewBag.idnvt = new SelectList(db.Navette, "id", "fromCity");
            return View();
        }

        // POST: Offres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NmbAbone,Stiuation,prix,idnvt")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Offre.Add(offre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idnvt = new SelectList(db.Navette, "id", "fromCity", offre.idnvt);
            return View(offre);
        }

        // GET: Offres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offre.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            ViewBag.idnvt = new SelectList(db.Navette, "id", "fromCity", offre.idnvt);
            return View(offre);
        }

        // POST: Offres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NmbAbone,Stiuation,prix,idnvt")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idnvt = new SelectList(db.Navette, "id", "fromCity", offre.idnvt);
            return View(offre);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offre.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = db.Offre.Find(id);
            db.Offre.Remove(offre);
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
        public ActionResult OffresCRUD()
        {
            return View(db.Offre.ToList());
        }
    }
}
