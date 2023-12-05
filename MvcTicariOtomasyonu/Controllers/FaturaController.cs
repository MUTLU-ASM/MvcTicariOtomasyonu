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
            return View("FaturaGetir", deger);
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
        public ActionResult Dinamik()
        {
            Class2 cs = new Class2();
            cs.deger1 = db.Faturalars.ToList();
            cs.deger2 = db.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string seriNo, string sıraNo, DateTime tarih, string vergiDairesi, string saat, string teslimVeren, string teslimAlan, string toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.seriNo = seriNo;
            f.sıraNo = sıraNo;
            f.tarih = tarih;
            f.vergiDairesi = vergiDairesi;
            f.saat = saat;
            f.teslimVeren = teslimVeren;
            f.teslimAlan = teslimAlan;
            f.toplam = decimal.Parse(toplam);
            db.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.aciklama = x.aciklama;
                fk.birimFiyat = x.birimFiyat;
                fk.faturalarId = x.id;
                fk.miktar = x.miktar;
                fk.tutar = x.tutar;
                db.FaturaKalems.Add(fk);
            }
            db.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}