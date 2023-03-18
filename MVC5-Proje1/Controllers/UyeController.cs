using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC5_Proje1.Controllers
{
    public class UyeController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Uye
        public ActionResult Index(int sayfa=1)
        {
            var x = db.TBL_Uye.ToList().ToPagedList(sayfa,3);
            return View(x);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBL_Uye p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBL_Uye.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var x = db.TBL_Uye.Find(id);
            db.TBL_Uye.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UyeGuncelle(int id)
        {
            var x = db.TBL_Uye.Find(id);
            return View("UyeGuncelle", x);
        }
        [HttpPost]
        public ActionResult UyeGuncelle(TBL_Uye p)
        {
            var x = db.TBL_Uye.Find(p.Uyeid);
            x.Uyead = p.Uyead;
            x.Uyesoyad = p.Uyesoyad;
            x.Uyemail = p.Uyemail;
            x.Uyekullanıcıadı = p.Uyekullanıcıadı;
            x.Uyekullanıcısifre = p.Uyekullanıcısifre;
            x.UyeOkul = p.UyeOkul;
            x.Uyetelefon = p.Uyetelefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGecmis(int id)
        {
            var x = db.TBL_Hareket.Where(k => k.Alanuye == id).ToList();
            var y = db.TBL_Uye.Where(k => k.Uyeid == id).Select(z => z.Uyead + " " + z.Uyesoyad).FirstOrDefault();
            ViewBag.d2 = y;
            return View(x);
        }

    }
}