using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyonu.Models.Siniflar;

namespace MvcTicariOtomasyonu.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Kategoris.ToList();
            return View(degerler);
        }
        //Sayfa yuklendigi zaman calisacak metod
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        //Butona tiklandigi zaman calisacak
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult KategoriSil(int id)
        {
            var deger = db.Kategoris.Find(id);
            db.Kategoris.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var deger = db.Kategoris.Find(id);
            return View("KategoriGetir",deger);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var deger = db.Kategoris.Find(k.id);
            deger.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}