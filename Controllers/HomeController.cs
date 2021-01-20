using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using navettes.Models;

namespace navettes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trajets(String searching, String cherche)
        {
            ViewBag.Message = "Your application description page.";
            navetteEntities1 db = new navetteEntities1();
            return View(db.Navette.Where(x => x.fromCity.Contains(searching) && x.toCity.Contains(cherche) || searching == null).ToList());
 
        }

        public ActionResult Abonnement()
        {
            ViewBag.Message = "Your contact page.";
            navetteEntities1 db = new navetteEntities1();
            return View(db.Offre);
        }
    }
}