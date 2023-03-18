using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;

namespace MVC5_Proje1.Controllers
{
    public class PersonelController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Personel
        public ActionResult Index()
        {
            var data = db.TBL_Personel.ToList(); 
            return View(data);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBL_Personel p)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBL_Personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var x = db.TBL_Personel.Find(id);
            db.TBL_Personel.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelGetir(int id)
        {
            var x = db.TBL_Personel.Find(id);
            return View("PersonelGetir",x);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(TBL_Personel p)
        {
            var x = db.TBL_Personel.Find(p.Personelid);
            x.PersonelAdSoyad = p.PersonelAdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}