using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
namespace MVC5_Proje1.Controllers
{
    public class DuyuruController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();

        public ActionResult Index()
        {
            var x = db.TBL_DUYURULAR.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(TBL_DUYURULAR p )
        {
            db.TBL_DUYURULAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(int id)
        {
            var x = db.TBL_DUYURULAR.Find(id);
            var data1 = x.Kategori;
            ViewBag.d1 = data1;
            var data2 = x.icerik;
            ViewBag.d2 = data2;
            var data3 = x.Tarih;
            ViewBag.d3 = data3;
            return View(x);
        }
        public ActionResult DuyuruSil(int id)
        {
            var x = db.TBL_DUYURULAR.Find(id);
            db.TBL_DUYURULAR.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DuyuruGuncelle(int id)
        {
            var x = db.TBL_DUYURULAR.Find(id);
            //var d = Convert.ToDateTime(x.Tarih).ToShortDateString();
            //ViewBag.date1 = d;
            return View(x);
        }
        [HttpPost]
        public ActionResult DuyuruGuncelle(TBL_DUYURULAR p )
        {
            var x = db.TBL_DUYURULAR.Find(p.id);
            x.icerik = p.icerik;
            x.Kategori = p.Kategori;
            x.Tarih = p.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}