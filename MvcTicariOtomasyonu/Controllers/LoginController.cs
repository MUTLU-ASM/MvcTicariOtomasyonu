using MvcTicariOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcTicariOtomasyonu.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialCariKayit()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialCariKayit(Current c)
        {
            db.currents.Add(c);
            db.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult PartialCariGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PartialCariGiris(Current c)
        {
            var bilgiler = db.currents.FirstOrDefault(x => x.mail == c.mail && x.sifre == c.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.mail, false);
                Session["mail"] = bilgiler.mail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminLogin(Admin a)
        {
            var bilgiler = db.Admins.FirstOrDefault(x => x.ad == a.ad && x.sifre == a.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.ad, false);
                Session["ad"]=bilgiler.ad.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}