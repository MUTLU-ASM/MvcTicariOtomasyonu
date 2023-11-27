using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var degerler = db.currents.FirstOrDefault(x => x.mail == cariMail);
            ViewBag.m = cariMail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var cariMail = (string)Session["mail"];
            var id = db.currents.Where(x => x.mail == cariMail.ToString()).Select(y => y.id).FirstOrDefault();
            var degerler = db.SatisHarekets.Where(x => x.id == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var cariMail = (string)Session["mail"];
            var degerler = db.Mesajlars.Where(x => x.alici == cariMail).OrderByDescending(x=>x.id).ToList();
            var gelenSayisi = db.Mesajlars.Count(x => x.alici == cariMail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            var gidenSayisi = db.Mesajlars.Count(x => x.gonderici == cariMail).ToString();
            ViewBag.gidenMesaj = gidenSayisi;
            return View(degerler);
        }
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
    }
}