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
    public class AbonnementsController : Controller
    {
        private navetteEntities1 db = new navetteEntities1();

        // GET: Abonnements
        public ActionResult Index()
        {
            var abonnement = db.Abonnement.Include(a => a.Offre).Include(a => a.Voyageur);
            return View(abonnement.ToList());
        }

        // GET: Abonnements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnement abonnement = db.Abonnement.Find(id);
            if (abonnement == null)
            {
                return HttpNotFound();
            }
            return View(abonnement);
        }

        // GET: Abonnements/Create
        public ActionResult Create()
        {
            ViewBag.idoffre = new SelectList(db.Offre, "id", "id");
            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN");
            return View();
        }

        // POST: Abonnements/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,dateDebut,dateFin,idoffre,idusr")] Abonnement abonnement)
        {
            if (ModelState.IsValid)
            {
                db.Abonnement.Add(abonnement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idoffre = new SelectList(db.Offre, "id", "id", abonnement.idoffre);
            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN", abonnement.idusr);
            return View(abonnement);
        }

        // GET: Abonnements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnement abonnement = db.Abonnement.Find(id);
            if (abonnement == null)
            {
                return HttpNotFound();
            }
            ViewBag.idoffre = new SelectList(db.Offre, "id", "id", abonnement.idoffre);
            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN", abonnement.idusr);
            return View(abonnement);
        }

        // POST: Abonnements/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,dateDebut,dateFin,idoffre,idusr")] Abonnement abonnement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonnement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idoffre = new SelectList(db.Offre, "id", "id", abonnement.idoffre);
            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN", abonnement.idusr);
            return View(abonnement);
        }

        // GET: Abonnements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnement abonnement = db.Abonnement.Find(id);
            if (abonnement == null)
            {
                return HttpNotFound();
            }
            return View(abonnement);
        }

        // POST: Abonnements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abonnement abonnement = db.Abonnement.Find(id);
            db.Abonnement.Remove(abonnement);
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
        public ActionResult AbonnementsCRUD()
        {
            return View(db.Abonnement.ToList());
        }
    }
}
