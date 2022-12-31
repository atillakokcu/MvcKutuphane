using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}