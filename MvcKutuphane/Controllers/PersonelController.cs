using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblPersonel.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");//data.announ da koşul sağlanmadıysa personel ekleye egri dön demek oluyor
            }
            db.TblPersonel.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult PersonelSil(int Id)
        {
            var Personel = db.TblPersonel.Find(Id);
            db.TblPersonel.Remove(Personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int Id) // neden sadece buraya ıd isili parametre verdiğimiz de algılıyor
        {

            var ktg = db.TblPersonel.Find(Id);
            return View("PersonelGetir", ktg);
        }

        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            var ktg = db.TblPersonel.Find(p.PersonelId);
            ktg.Personel = p.Personel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}