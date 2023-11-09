using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyonu.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context db = new Context();
        public ActionResult Index()
        {
            DetayUrun u = new DetayUrun();
            //var degerler = db.Uruns.Where(x => x.id == 1).ToList();
            u.urunDeger=db.Uruns.Where(x => x.id == 1).ToList();
            u.detayDeger=db.Detays.Where(y => y.id == 1).ToList();
            return View(u);
        }
    }
}