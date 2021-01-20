using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using navettes.Models;
using System.Web.Security;
namespace navettes.Controllers
{
    public class AdministrateursController : Controller
    {
        private navetteEntities1 db = new navetteEntities1();

        // GET: Administrateurs

        public ActionResult Index()
        {
            return View(db.Administrateur.ToList());
        }
        public ActionResult Log()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Log(Models.Administrateur model)
        {
            using (var context = new navetteEntities1())
            {
                bool isValid = context.Administrateur.Any(x => x.admLog == model.admLog && x.mdp == model.mdp);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.admLog, false);
                    return RedirectToAction("Index", "Administrateurs");
                }
                ModelState.AddModelError("", "Mot de passe ou nom d utilisateur irroné");
            }
            return View();
        }

        // GET: Administrateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = db.Administrateur.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // GET: Administrateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,admLog,mdp")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Administrateur.Add(administrateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrateur);
        }

        // GET: Administrateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = db.Administrateur.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // POST: Administrateurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,admLog,mdp")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrateur);
        }

        // GET: Administrateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = db.Administrateur.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // POST: Administrateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrateur administrateur = db.Administrateur.Find(id);
            db.Administrateur.Remove(administrateur);
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

        public ActionResult AdminCRUD()
        {
            return View(db.Administrateur.ToList());
        }
    }
}
