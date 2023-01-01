using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbKutuphaneEntities Db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var YazarlarListesi = Db.TblYazar.ToList();
            return View(YazarlarListesi);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TblYazar Yazar)
        {
            Db.TblYazar.Add(Yazar);
            Db.SaveChanges();
            return View();
        }

        public ActionResult YazarSil(int id)
        {
            var Yazar = Db.TblYazar.Find(id);
            Db.TblYazar.Remove(Yazar);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int Id)
        {
            var Yazar = Db.TblYazar.Find(Id);
            return View("YazarGetir", Yazar);

        }
        public ActionResult YazarGuncelle(TblYazar Yazar)
        {
            var YazarDetay = Db.TblYazar.Find(Yazar.YazarId);
            YazarDetay.YazarAdi = Yazar.YazarAdi;
            YazarDetay.YazarSoyad = Yazar.YazarSoyad;
            YazarDetay.YazarDetay = Yazar.YazarDetay;
            Db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}