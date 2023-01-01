using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var Kitaplar = db.TblKitap.ToList();
            return View(Kitaplar);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem>deger1 = (from i in db.TblKatagori.ToList() 
                                          select new SelectListItem { Text = i.Ad,Value=i.KategoriId.ToString()}).ToList();

            ViewBag.Katagori = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList() select new SelectListItem { Text = i.YazarAdi, Value = i.YazarId.ToString() }).ToList(); 
            ViewBag.Yazar = deger2;
            return View();

        }
        [HttpPost]
        public ActionResult KitapEkle(TblKitap Kitap)
        {
            return View();
        }




    }
}