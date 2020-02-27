using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        dbMvcStokEntities db = new dbMvcStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.tblKategoriler.ToList();
            var degerler = db.tblKategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(tblKategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tblKategoriler.Add(p1);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.tblKategoriler.Find(id);
            db.tblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblKategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(tblKategoriler p1)
        {
            var ktg = db.tblKategoriler.Find(p1.KategoriId);
            ktg.KategoriAdi = p1.KategoriAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}