using MvcTicariOtomasyonu.Models.Siniflar;
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
    }
}