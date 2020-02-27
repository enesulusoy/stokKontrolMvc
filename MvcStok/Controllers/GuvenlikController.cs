using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        dbMvcStokEntities db = new dbMvcStokEntities();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(tblKullanici t)
        {
            var bilgiler = db.tblKullanici.FirstOrDefault(x => x.Ad == t.Ad && x.Sifre == t.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Ad, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }
        }
    }
}