﻿using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikCiz = new Chart(600, 600);
            grafikCiz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = db.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ad));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.stok));
            var grafik = new Chart(1000, 1000);
            grafik.AddTitle("Stoklar").AddSeries(
                chartType: "Pie",
                name: "Stok",
                xValue: xvalue,
                yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif1> UrunListesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                urunad = "Bilgisayar",
                stok = 120
            });
            snf.Add(new sinif1()
            {
                urunad = "Beyaz Eşya",
                stok = 150
            }); snf.Add(new sinif1()
            {
                urunad = "Mobilya",
                stok = 70
            }); snf.Add(new sinif1()
            {
                urunad = "Küçük Ev Aletleri",
                stok = 180
            }); snf.Add(new sinif1()
            {
                urunad = "Mobil Cihazlar",
                stok = 90
            });
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        { 
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using (var context = new Context())
            {
                snf=db.Uruns.Select(x=>new sinif2
                {
                    urunAd=x.ad,
                    urunStok=x.stok
                }).ToList();
            }
            return snf;
        }

        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}