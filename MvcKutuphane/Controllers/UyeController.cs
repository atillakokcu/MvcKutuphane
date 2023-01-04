using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        // GET: Uye
        


        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TblUyeler.ToList();
            var degerler = db.TblUyeler.ToList().ToPagedList(sayfa,3);
            return View(degerler);
            
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");//data.announ da koşul sağlanmadıysa personel ekleye egri dön demek oluyor
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int Id)
        {
            var Uyeler = db.TblUyeler.Find(Id);
            db.TblUyeler.Remove(Uyeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int Id) // neden sadece buraya ıd isili parametre verdiğimiz de algılıyor
        {

            var ktg = db.TblUyeler.Find(Id);
            return View("UyeGetir", ktg);
        }

        public ActionResult UyeGuncelle(TblUyeler p)
        {
            var ktg = db.TblUyeler.Find(p.UyeId);
            ktg.UyeAdi = p.UyeAdi;
            ktg.UyeSoyadi= p.UyeSoyadi;
            ktg.KullaniciAdi = p.KullaniciAdi;
            ktg.Okul= p.Okul;
            ktg.Mail= p.Mail;
            ktg.Sifre= p.Sifre;
            ktg.Fotograf= p.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}