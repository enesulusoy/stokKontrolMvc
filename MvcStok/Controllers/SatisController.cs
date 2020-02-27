using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        dbMvcStokEntities db = new dbMvcStokEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(tblSatislar p)
        {
            db.tblSatislar.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}