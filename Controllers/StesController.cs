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
    public class StesController : Controller
    {
        private navetteEntities1 db = new navetteEntities1();

        // GET: Stes
        public ActionResult Index()
        {
            return View(db.Ste.ToList());
        }

        // GET: Stes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ste ste = db.Ste.Find(id);
            if (ste == null)
            {
                return HttpNotFound();
            }
            return View(ste);
        }

        // GET: Stes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nomste,Emailste,mdpSte")] Ste ste)
        {
            if (ModelState.IsValid)
            {
                db.Ste.Add(ste);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(ste);
        }

        // GET: Stes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ste ste = db.Ste.Find(id);
            if (ste == null)
            {
                return HttpNotFound();
            }
            return View(ste);
        }

        // POST: Stes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nomste,Emailste,mdpSte")] Ste ste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ste);
        }

        // GET: Stes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ste ste = db.Ste.Find(id);
            if (ste == null)
            {
                return HttpNotFound();
            }
            return View(ste);
        }

        // POST: Stes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ste ste = db.Ste.Find(id);
            db.Ste.Remove(ste);
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Ste model)
        {
            using (var context = new navetteEntities1())
            {
                bool isValid = context.Ste.Any(x => x.Emailste == model.Emailste && x.mdpSte == model.mdpSte);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Emailste, false);
                    return RedirectToAction("Index", "Stes");
                }
                ModelState.AddModelError("", "Mot de passe ou email irroné");
            }
            return View();
        }
        public ActionResult SteCRUD()
        {
            return View(db.Ste.ToList());
        }
    }
}
