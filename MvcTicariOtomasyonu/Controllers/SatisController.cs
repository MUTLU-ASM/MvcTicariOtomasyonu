using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            ListDoldur();
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            ListDoldur();
            var deger = db.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var deger = db.SatisHarekets.Find(s.id);
            deger.currentId = s.currentId;
            deger.adet = s.adet;
            deger.fiyat = s.fiyat;
            deger.personelId = s.personelId;
            deger.tarih = s.tarih;
            deger.toplamTutar = s.toplamTutar;
            deger.urunId = s.urunId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.id == id).ToList();
            return View(degerler);
        }



        public void ListDoldur()
        {
            List<SelectListItem> dgrUrun = (from x in db.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad,
                                                Value = x.id.ToString()
                                            }
                ).ToList();
            List<SelectListItem> dgrCari = (from x in db.currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad + " " + x.soyad,
                                                Value = x.id.ToString()
                                            }
     ).ToList();
            List<SelectListItem> dgrPers = (from x in db.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad + " " + x.soyad,
                                                Value = x.id.ToString()
                                            }
     ).ToList();
            ViewBag.dgrUrun = dgrUrun;
            ViewBag.dgrCari = dgrCari;
            ViewBag.dgrPers = dgrPers;
        }
    }
}