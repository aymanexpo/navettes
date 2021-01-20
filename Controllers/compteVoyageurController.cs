using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using navettes.Models;
using System.Web.Security;
using System.Data;
using System.Data.Entity;
using System.Net;


namespace navettes.Controllers
{
    public class compteVoyageurController : Controller
    {
        // GET: compteVoyageur
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Voyageur model)
        {
            using (var context = new navetteEntities1())
            {
                bool isValid = context.Voyageur.Any(x => x.EmailUSR == model.EmailUSR && x.mdpUSR == model.mdpUSR);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.EmailUSR, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","Mot de passe ou nom d utilisateur irroné");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Voyageur model)
        {
            using (var context = new navetteEntities1())
            {
                context.Voyageur.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Administrateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyageur voyageur = db.Voyageur.Find(id);
            if (voyageur == null)
            {
                return HttpNotFound();
            }
            return View("VoyageurCRUD");
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
        public ActionResult Create([Bind(Include = "id,CIN,FirstName,lastName,EmailUSR,mdpUSR,tel")] Voyageur voyageur)
        {
            if (ModelState.IsValid)
            {
                db.Voyageur.Add(voyageur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voyageur);
        }

        // GET: Administrateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyageur voyageur = db.Voyageur.Find(id);
            if (voyageur == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Administrateurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CIN,FirstName,lastName,EmailUSR,mdpUSR,tel")] Voyageur voyageur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voyageur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voyageur);
        }

        // GET: Administrateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyageur voyageur = db.Voyageur.Find(id);
            if (voyageur == null)
            {
                return HttpNotFound();
            }
            return View(voyageur);
        }

        // POST: compteVoyageur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voyageur voyageur = db.Voyageur.Find(id);
            db.Voyageur.Remove(voyageur);
            db.SaveChanges();
            return RedirectToAction("Index", "Administrateurs");
        }
        //
        private navetteEntities1 db = new navetteEntities1();
        public ActionResult VoyageurCRUD()
        {
            return View(db.Voyageur.ToList());
        }
    }
}