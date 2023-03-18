using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;

namespace MVC5_Proje1.Controllers
{
    public class YazarlarController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Yazarlar
        public ActionResult Index()
        {
            var data = db.TBL_Yazar.ToList();   
            return View(data);
        }
        public ActionResult YazarSil(int id)
        {
            var data = db.TBL_Yazar.Find(id);
            db.TBL_Yazar.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Yazargetir(int id)
        {
            var x = db.TBL_Yazar.Find(id);
            return View("YazarGetir",x);
        }
        [HttpPost]
        public ActionResult YazarGuncelle(TBL_Yazar p)
        {
            var x = db.TBL_Yazar.Find(p.Yazarid);
            x.yazarad = p.yazarad;
            x.yazarsoyad = p.yazarsoyad;
            x.yazardetay = p.yazardetay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        public ActionResult YazarEkle(TBL_Yazar p)
        {
            if(!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBL_Yazar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitap(int id)
        {
            var x = db.TBL_Kitap.Where(k => k.Kitapyazar == id).ToList();
            var data1 = db.TBL_Yazar.Where(k => k.Yazarid==id).Select(z=>z.yazarad + " " + z.yazarsoyad).FirstOrDefault();
            ViewBag.d1 = data1;
            return View(x);
        }
    }
}