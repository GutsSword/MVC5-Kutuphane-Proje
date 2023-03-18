using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
namespace MVC5_Proje1.Controllers
{
    public class OduncController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        [Authorize(Roles = "A")]
        public ActionResult Index(TBL_Hareket p)
        {
            var x = db.TBL_Hareket.Where(k => k.islemdurum == false).ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBL_Uye.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Uyead + " " + x.Uyesoyad,
                                               Value = x.Uyeid.ToString()
                                           }).ToList();
            ViewBag.d1 = deger1;

            List<SelectListItem> deger2 = (from x in db.TBL_Kitap.Where(k=>k.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Kitapad,
                                               Value = x.Kitapid.ToString()
                                           }).ToList();
            ViewBag.d2 = deger2;

            List<SelectListItem> deger3 = (from x in db.TBL_Personel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAdSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.d3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBL_Hareket p)
        {
            var d1 = db.TBL_Uye.Where(x => x.Uyeid == p.TBL_Uye.Uyeid).FirstOrDefault();
            var d2 = db.TBL_Kitap.Where(x => x.Kitapid == p.TBL_Kitap.Kitapid).FirstOrDefault();
            var d3 = db.TBL_Personel.Where(x => x.Personelid == p.TBL_Personel.Personelid).FirstOrDefault();
            p.TBL_Uye = d1;
            p.TBL_Kitap = d2;
            p.TBL_Personel = d3;
            db.TBL_Hareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Odunciade(int id)
        {
            var x = db.TBL_Hareket.Find(id);
            DateTime dt1 = DateTime.Parse(x.iadetarihi.ToString());
            DateTime dt2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan dt3 = dt2 - dt1;
            ViewBag.data = dt3.TotalDays;
            return View("Odunciade", x);
        }
        [HttpPost]
        public ActionResult OduncGuncelle(TBL_Hareket p)
        {
            var x = db.TBL_Hareket.Find(p.Hareketid);
            x.uyegetirtarih = p.uyegetirtarih;
            x.islemdurum = true;
            if (x.islemdurum == true)
            {
                x.TBL_Kitap.Durum = true;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}