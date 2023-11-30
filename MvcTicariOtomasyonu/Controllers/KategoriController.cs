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
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context db = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            //ToPagedList(BaslangicParametresi,kaçtanegösterilecek);
            var degerler = db.Kategoris.ToList().ToPagedList(sayfa, 4);
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
        public ActionResult KategoriSil(int id)
        {
            var deger = db.Kategoris.Find(id);
            db.Kategoris.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var deger = db.Kategoris.Find(id);
            return View("KategoriGetir", deger);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var deger = db.Kategoris.Find(k.id);
            deger.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            Class1 cs = new Class1();
            cs.kategoriler = new SelectList(db.Kategoris, "id", "ad");
            cs.urunler = new SelectList(db.Uruns, "id", "ad");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunListesi = (from x in db.Uruns
                               join y in db.Kategoris
                               on x.kategori.id equals y.id
                               where x.kategori.id == p
                               select new
                               {
                                   Text = x.ad,
                                   Value = x.id.ToString()
                               }).ToList();
            return Json(urunListesi, JsonRequestBehavior.AllowGet);
        }
    }
}