using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyonu.Models.Siniflar;

namespace MvcTicariOtomasyonu.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Carilers.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler c)
        {
            c.durum = true;
            db.Carilers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");        
        }
        public ActionResult CariSil(int id)
        {
            var deger = db.Carilers.Find(id);
            deger.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var deger = db.Carilers.Find(id);
            return View("CariGetir",deger);
        }
        public ActionResult CariGuncelle(Cariler c)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var deger = db.Carilers.Find(c.id);
            deger.ad = c.ad;
            deger.soyad = c.soyad;
            deger.sehir = c.sehir;
            deger.mail = c.mail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.cariId == id).ToList();
            var cr = db.Carilers.Where(x => x.id == id).Select(y => y.ad + " " + y.soyad).FirstOrDefault();
            ViewBag.dc = cr;
            return View(degerler);
        }
    }
}