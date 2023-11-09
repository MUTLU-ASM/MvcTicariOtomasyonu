using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context db = new Context();
        public ActionResult Index()
        {
            var deger1 = db.currents.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = db.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = db.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = db.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = db.Uruns.Sum(x=>x.stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in db.Uruns select x.marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = db.Uruns.Count(x=>x.stok<=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in db.Uruns orderby x.satisFiyat descending select x.ad).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in db.Uruns orderby x.satisFiyat ascending select x.ad).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = db.Uruns.GroupBy(x => x.marka).OrderByDescending(z => z.Count()).Select(z => z.Key).FirstOrDefault(); ;
            ViewBag.d10 = deger10;
            var deger11 = db.Uruns.Count(x => x.ad == "Buzdolabı").ToString();
            ViewBag.d11 = deger11;
            var deger12 = db.Uruns.Count(x=>x.ad=="Laptop").ToString();
            ViewBag.d12 = deger12;
            var deger13 =db.Uruns.Where(u=>u.id== db.SatisHarekets.GroupBy(x=>x.urunId).OrderByDescending(z => z.Count()).Select(z => z.Key).FirstOrDefault()).Select(k=>k.ad).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = db.SatisHarekets.Sum(x=>x.toplamTutar).ToString();
            ViewBag.d14 = deger14;
            var deger15 = db.SatisHarekets.Count(x => x.tarih == DateTime.Today).ToString();
            ViewBag.d15 = deger15;
            var deger16 = db.SatisHarekets.Where(x => x.tarih == DateTime.Today).Sum(y=>y.toplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
    }
}