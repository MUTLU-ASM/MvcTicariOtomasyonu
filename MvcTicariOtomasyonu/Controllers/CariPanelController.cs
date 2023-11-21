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
            var degerler=db.currents.FirstOrDefault(x=>x.mail==cariMail);
            ViewBag.m = cariMail;
            return View(degerler);
        }  
        public ActionResult Siparislerim()
        {
            var cariMail = (string)Session["mail"];
            var id=db.currents.Where(x=>x.mail==cariMail.ToString()).Select(y=>y.id).FirstOrDefault();
            var degerler = db.SatisHarekets.Where(x => x.id == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var cariMail = (string)Session["mail"];
            var degerler = db.Mesajlars.Where(x=>x.alici==cariMail).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}