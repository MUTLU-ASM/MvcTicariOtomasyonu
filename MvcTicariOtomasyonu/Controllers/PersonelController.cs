using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger = (from x in db.Departmen.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ad,
                                              Value = x.id.ToString()
                                          }
                              ).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            db.Personels.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> dgr = (from x in db.Departmen.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ad,
                                              Value = x.id.ToString()
                                          }
                  ).ToList();
            ViewBag.dgr = dgr;
            var deger = db.Personels.Find(id);
            return View("PersonelGetir",deger);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var deger = db.Personels.Find(p.id);
            deger.ad = p.ad;
            deger.soyad = p.soyad;
            deger.gorsel = p.gorsel;
            deger.departmanId = p.departmanId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}