using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
namespace MVC5_Proje1.Controllers
{
    public class AyarlarController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Ayarlar
        public ActionResult Index()
        {
            var x = db.TBL_Admin.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TBL_Admin p)
        {
            db.TBL_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var x = db.TBL_Admin.Find(id);
            db.TBL_Admin.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var x = db.TBL_Admin.Find(id);
            return View("AdminGuncelle",x);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBL_Admin p)
        {
            var x = db.TBL_Admin.Find(p.ID);
            x.Kullanici = p.Kullanici;
            x.Sifre = p.Sifre;
            x.Yetki = p.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}