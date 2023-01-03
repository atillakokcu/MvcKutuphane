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
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TblKitap select k;
            //var Kitaplar = db.TblKitap.ToList();
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar=kitaplar.Where(m=>m.KitapAdi.Contains(p));
            }
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TblKatagori.ToList()
                                           select new SelectListItem { Text = i.Ad, Value = i.KategoriId.ToString() }).ToList();

            ViewBag.Katagori = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList() select new SelectListItem { Text = i.YazarAdi, Value = i.YazarId.ToString() }).ToList();
            ViewBag.Yazar = deger2;
            return View();

        }
        [HttpPost]
        public ActionResult KitapEkle(TblKitap Kitap)
        {
            var ktg = db.TblKatagori.Where(k=>k.KategoriId==Kitap.TblKatagori.KategoriId).FirstOrDefault();
            var yzr = db.TblYazar.Where(y=>y.YazarId==Kitap.TblYazar.YazarId).FirstOrDefault();

            Kitap.TblKatagori= ktg;
            Kitap.TblYazar= yzr;
            db.TblKitap.Add(Kitap);
            db.SaveChanges();
            return RedirectToAction("Index");

           
        }
        public ActionResult KitapSil(int Id)
        {
            var Kitap = db.TblKitap.Find(Id);
            db.TblKitap.Remove(Kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int Id)
        {
            var ktp = db.TblKitap.Find(Id);

            List<SelectListItem> deger1 = (from i in db.TblKatagori.ToList()
                                           select new SelectListItem { Text = i.Ad, Value = i.KategoriId.ToString() }).ToList();

            ViewBag.Katagori = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList() select new SelectListItem { Text = i.YazarAdi, Value = i.YazarId.ToString() }).ToList();
            ViewBag.Yazar = deger2;
            
            return View("KitapGetir",ktp);
        }

        public ActionResult KitapGuncelle(TblKitap Kitap)
        {
            var KitapBul = db.TblKitap.Find(Kitap.KitapId);
            KitapBul.KitapAdi=Kitap.KitapAdi.ToString();
            KitapBul.BasimYil = Kitap.BasimYil.ToString();
            KitapBul.Sayfa=Kitap.Sayfa.ToString();  
            KitapBul.YayinEvi = Kitap.YayinEvi.ToString();

            var ktg =db.TblKatagori.Where(k=>k.KategoriId==Kitap.TblKatagori. KategoriId).FirstOrDefault();
            var yzr = db.TblYazar.Where(y=>y.YazarId == Kitap.TblYazar.YazarId).FirstOrDefault();
            KitapBul.KategoriId=ktg.KategoriId;
            KitapBul.YazarId=yzr.YazarId;
            db.SaveChanges();
            


            return RedirectToAction("Index");
        }


    }
}