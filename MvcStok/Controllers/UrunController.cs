using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        dbMvcStokEntities db = new dbMvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.tblUrunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.tblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAdi,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(tblUrunler p1)
        {
            var ktg = db.tblKategoriler.Where(m => m.KategoriId == p1.tblKategoriler.KategoriId).FirstOrDefault();
            p1.tblKategoriler = ktg;
            db.tblUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.tblUrunler.Find(id);
            db.tblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.tblUrunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAdi,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(tblUrunler p)
        {
            var urun = db.tblUrunler.Find(p.UrunId);
            urun.UrunAdi = p.UrunAdi;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.Fiyat = p.Fiyat;
            //urun.UrunKategori = p1.UrunKategori;
            var ktg = db.tblKategoriler.Where(m => m.KategoriId == p.tblKategoriler.KategoriId).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}