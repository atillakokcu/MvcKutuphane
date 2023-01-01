using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TblKitap Kitap)
        {
            return View();
        }




    }
}