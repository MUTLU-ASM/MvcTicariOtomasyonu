﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyonu.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context db = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var degerler = db.Uruns.Where(x => x.ad.Contains(p) || p == null).ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger = (from x in db.Kategoris.ToList()
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
        public ActionResult YeniUrun(Urun u)
        {
            db.Uruns.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = db.Uruns.Find(id);
            deger.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> dgr = (from x in db.Kategoris.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }
                               ).ToList();
            ViewBag.dgr = dgr;
            var deger = db.Uruns.Find(id);
            return View("UrunGetir", deger);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = db.Uruns.Find(u.id);
            urn.alisFiyat = u.alisFiyat;
            urn.durum = u.durum;
            urn.satisFiyat = u.satisFiyat;
            urn.kategoriId = u.kategoriId;
            urn.marka = u.marka;
            urn.stok = u.stok;
            urn.ad = u.ad;
            urn.gorsel = u.gorsel;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var degerler = db.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> dgrPers = (from x in db.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad + " " + x.soyad,
                                                Value = x.id.ToString()
                                            }
).ToList();
            ViewBag.dgrPers = dgrPers;
            var deger = db.Uruns.Find(id);
            ViewBag.dgrID=deger.id;
            ViewBag.dgrFiyat=deger.satisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket s)
        {
            s.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}