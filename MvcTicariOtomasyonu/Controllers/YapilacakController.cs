using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.dgCari = db.currents.Count().ToString();
            ViewBag.dgUrun = db.Uruns.Count().ToString();
            ViewBag.dgKateg = db.Kategoris.Count().ToString();
            ViewBag.dgCariSehir = (from x in db.currents select x.sehir).Distinct().Count().ToString();
            var degerler = db.Yapilacaks.ToList();
            return View(degerler);
        }
    }
}