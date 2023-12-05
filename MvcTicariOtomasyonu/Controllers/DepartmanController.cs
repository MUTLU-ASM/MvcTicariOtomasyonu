using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyonu.Models.Siniflar;

namespace MvcTicariOtomasyonu.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Departmen.Where(x => x.durum == true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.durum = true;
            db.Departmen.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var deger = db.Departmen.Find(id);
            deger.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var deger = db.Departmen.Find(id);
            return View("DepartmanGetir", deger);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var deger = db.Departmen.Find(d.id);
            deger.ad = d.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = db.Personels.Where(x => x.departmanId == id).ToList();
            var dpt = db.Departmen.Where(x => x.id == id).Select(y => y.ad).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = db.SatisHarekets.Where(x=>x.personelId==id).ToList();
            var per = db.Personels.Where(x => x.id == id).Select(y => y.ad +" "+ y.soyad).FirstOrDefault();
            ViewBag.dp = per;
            return View(degerler);
        }
    }
}