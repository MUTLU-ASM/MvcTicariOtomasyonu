using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context db = new Context();
        public ActionResult Index()
        {
            var kargolar = db.kargoDetays.ToList();
            return View(kargolar);
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay k)
        {
            db.kargoDetays.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}