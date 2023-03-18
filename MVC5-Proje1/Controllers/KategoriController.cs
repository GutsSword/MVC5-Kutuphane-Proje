using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
namespace MVC5_Proje1.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        public ActionResult Index()
        {
            var x = db.TBL_Kategori.Where(k=>k.kategoridurum==true).ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBL_Kategori p)
        {
            db.TBL_Kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var x = db.TBL_Kategori.Find(id);
            x.kategoridurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var x = db.TBL_Kategori.Find(id);
            return View("KategoriGetir",x);
        }
        public ActionResult KategoriGuncelle(TBL_Kategori p)
        {
            var x = db.TBL_Kategori.Find(p.Kategoriid);
            x.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}