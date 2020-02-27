using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        dbMvcStokEntities db = new dbMvcStokEntities();

        [Authorize]
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tblMusteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAdi.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.tblMusteriler.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(tblMusteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tblMusteriler.Add(p1);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.tblMusteriler.Find(id);
            db.tblMusteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tblMusteriler.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(tblMusteriler p1)
        {
            var musteri = db.tblMusteriler.Find(p1.MusteriId);
            musteri.MusteriAdi = p1.MusteriAdi;
            musteri.MusteriSoyadi = p1.MusteriSoyadi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}