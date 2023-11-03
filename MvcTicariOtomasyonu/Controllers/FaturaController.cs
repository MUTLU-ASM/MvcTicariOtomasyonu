using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Faturalars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            db.Faturalars.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var deger = db.Faturalars.Find(id);
            return View("FaturaGetir",deger);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var deger = db.Faturalars.Find(f.id);
            deger.seriNo = f.seriNo;
            deger.sıraNo = f.sıraNo;
            deger.vergiDairesi = f.vergiDairesi;
            deger.tarih = f.tarih;
            deger.saat = f.saat;
            deger.teslimVeren = f.teslimVeren;
            deger.teslimAlan = f.teslimAlan;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = db.FaturaKalems.Where(x => x.faturalarId == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            db.FaturaKalems.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}