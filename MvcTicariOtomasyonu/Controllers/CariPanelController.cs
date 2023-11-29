using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcTicariOtomasyonu.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var cariMail = (string)Session["mail"];
            var degerler = db.Mesajlars.Where(x => x.alici == cariMail).ToList();
            ViewBag.m = cariMail;
            var mailID = db.currents.Where(x => x.mail == cariMail).Select(y => y.id).FirstOrDefault();
            ViewBag.mailID = mailID;
            var toplamSatis = db.SatisHarekets.Where(x => x.currentId == mailID).Count();
            ViewBag.toplamSatis = toplamSatis;
            var toplamTutar = db.SatisHarekets.Where(x => x.currentId == mailID).Sum(y => (decimal?)y.toplamTutar) ?? 0;
            ViewBag.toplamTutar = toplamTutar;
            var toplamUrun = db.SatisHarekets.Where(x => x.currentId == mailID).Sum(y => (int?)y.adet) ?? 0;
            ViewBag.toplamUrun = toplamUrun;
            var adSoyad = db.currents.Where(x => x.mail == cariMail).Select(y => y.ad + " " + y.soyad).FirstOrDefault();
            ViewBag.adSoyad = adSoyad;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var cariMail = (string)Session["mail"];
            var id = db.currents.Where(x => x.mail == cariMail.ToString()).Select(y => y.id).FirstOrDefault();
            var degerler = db.SatisHarekets.Where(x => x.id == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var cariMail = (string)Session["mail"];
            var degerler = db.Mesajlars.Where(x => x.alici == cariMail).OrderByDescending(x => x.id).ToList();
            var gelenSayisi = db.Mesajlars.Count(x => x.alici == cariMail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            var gidenSayisi = db.Mesajlars.Count(x => x.gonderici == cariMail).ToString();
            ViewBag.gidenMesaj = gidenSayisi;
            return View(degerler);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var cariMail = (string)Session["mail"];
            var degerler = db.Mesajlars.Where(x => x.alici == cariMail).OrderByDescending(x => x.id).ToList();
            var gidenSayisi = db.Mesajlars.Count(x => x.gonderici == cariMail).ToString();
            ViewBag.gidenMesaj = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Count(x => x.alici == cariMail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            return View(degerler);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = db.Mesajlars.Where(x => x.id == id).ToList();
            var cariMail = (string)Session["mail"];
            var gidenSayisi = db.Mesajlars.Count(x => x.gonderici == cariMail).ToString();
            ViewBag.gidenMesaj = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Count(x => x.alici == cariMail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var cariMail = (string)Session["mail"];
            var gidenSayisi = db.Mesajlars.Count(x => x.gonderici == cariMail).ToString();
            ViewBag.gidenMesaj = gidenSayisi;
            var gelenSayisi = db.Mesajlars.Count(x => x.alici == cariMail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var cariMail = (string)Session["mail"];
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.gonderici = cariMail;
            db.Mesajlars.Add(m);
            db.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult KargoTakip(string k)
        {
            var kargolar = from x in db.kargoDetays select x;
            kargolar = kargolar.Where(y => y.takipKodu.Contains(k));

            return View(kargolar.ToList()); ;
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = db.kargoTakips.Where(x => x.takipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult PartialAyarlar()
        {
            var cariMail = (string)Session["mail"];
            var id = db.currents.Where(x => x.mail == cariMail).Select(y => y.id).FirstOrDefault();
            var cariBul = db.currents.Find(id);
            return PartialView("PartialAyarlar",cariBul);
        }      
        public PartialViewResult PartialDuyuru()
        {
            var veriler = db.Mesajlars.Where(x => x.gonderici == "admin").OrderByDescending(x=>x.tarih).ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Current c)
        {
            var cari = db.currents.Find(c.id);
            cari.ad = c.ad;
            cari.soyad = c.soyad;
            cari.sifre = c.sifre;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}