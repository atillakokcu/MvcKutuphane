using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TblKatagori.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TblKatagori katagori)
        {
            db.TblKatagori.Add(katagori);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(byte Id)
        {
            var Kategori = db.TblKatagori.Find(Id);
            db.TblKatagori.Remove(Kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int Id) // neden sadece buraya ıd isili parametre verdiğimiz de algılıyor
        {

            var ktg = db.TblKatagori.Find(Id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(TblKatagori Kategori)
        {
            var ktg = db.TblKatagori.Find(Kategori.KategoriId);
            ktg.Ad = Kategori.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}