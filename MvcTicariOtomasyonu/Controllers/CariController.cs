using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyonu.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context db = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.currents.Where(x => x.durum == true).ToList().ToPagedList(sayfa, 8);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Current c)
        {
            c.durum = true;
            db.currents.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var deger = db.currents.Find(id);
            deger.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var deger = db.currents.Find(id);
            return View("CariGetir", deger);
        }
        public ActionResult CariGuncelle(Current c)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var deger = db.currents.Find(c.id);
            deger.ad = c.ad;
            deger.soyad = c.soyad;
            deger.sehir = c.sehir;
            deger.mail = c.mail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.currentId == id).ToList();
            var cr = db.currents.Where(x => x.id == id).Select(y => y.ad + " " + y.soyad).FirstOrDefault();
            ViewBag.dc = cr;
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var degerler = db.Mesajlars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}