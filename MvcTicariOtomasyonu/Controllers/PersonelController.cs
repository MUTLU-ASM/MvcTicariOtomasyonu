using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (Request.Files.Count>0)
            {
                string dosyaAdi=Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/"+dosyaAdi+uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.gorsel="/Image/"+dosyaAdi+uzanti;
            }
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
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.gorsel = "/Image/" + dosyaAdi + uzanti;
            }
            var deger = db.Personels.Find(p.id);
            deger.ad = p.ad;
            deger.soyad = p.soyad;
            deger.gorsel = p.gorsel;
            deger.departmanId = p.departmanId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var sorgu = db.Personels.ToList();
            return View(sorgu);
        }
    }
}