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
    public class DemandesController : Controller
    {
        private navetteEntities1 db = new navetteEntities1();

        // GET: Demandes
        public ActionResult Index()
        {
            var demande = db.Demande.Include(d => d.Voyageur);
            return View(demande.ToList());
        }

        // GET: Demandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande demande = db.Demande.Find(id);
            if (demande == null)
            {
                return HttpNotFound();
            }
            return View(demande);
        }

        // GET: Demandes/Create
        public ActionResult Create()
        {
            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN");
            return View();
        }

        // POST: Demandes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fromCity,toCity,timeGo,timeWent,idusr")] Demande demande)
        {
            if (ModelState.IsValid)
            {
                db.Demande.Add(demande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN", demande.idusr);
            return View(demande);
        }

        // GET: Demandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande demande = db.Demande.Find(id);
            if (demande == null)
            {
                return HttpNotFound();
            }
            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN", demande.idusr);
            return View(demande);
        }

        // POST: Demandes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fromCity,toCity,timeGo,timeWent,idusr")] Demande demande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idusr = new SelectList(db.Voyageur, "id", "CIN", demande.idusr);
            return View(demande);
        }

        // GET: Demandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande demande = db.Demande.Find(id);
            if (demande == null)
            {
                return HttpNotFound();
            }
            return View(demande);
        }

        // POST: Demandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demande demande = db.Demande.Find(id);
            db.Demande.Remove(demande);
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
        public ActionResult DemandesCRUD()
        {
            return View(db.Demande.ToList());
        }
    }
}
