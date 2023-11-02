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
            List<SelectListItem> dgrUrun = (from x in db.Uruns.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }
                 ).ToList();
            List<SelectListItem> dgrCari = (from x in db.Carilers.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " "+ x.soyad,
                                            Value = x.id.ToString()
                                        }
     ).ToList();
            List<SelectListItem> dgrPers = (from x in db.Personels.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " "+ x.soyad,
                                            Value = x.id.ToString()
                                        }
     ).ToList();
            ViewBag.dgrUrun = dgrUrun;
            ViewBag.dgrCari = dgrCari;
            ViewBag.dgrPers = dgrPers;
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
    }
}