using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5_Proje1.Models.Entity;

namespace MVC5_Proje1.Controllers
{
    
    public class PanelimController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();

        public ActionResult Index()
        {
            var x = Session["Uyemail"].ToString();
            //var uye = db.TBL_Uye.FirstOrDefault(z=>z.Uyemail==x);
            var degerler = db.TBL_DUYURULAR.ToList();
            var d1 = db.TBL_Uye.Where(k => k.Uyemail == x).Select(y => y.Uyead).FirstOrDefault();
            ViewBag.v1 = d1;
            var d2 = db.TBL_Uye.Where(k => k.Uyemail == x).Select(y => y.Uyesoyad).FirstOrDefault();
            ViewBag.v2 = d2;
            var d3 = db.TBL_Uye.Where(k => k.Uyemail == x).Select(y => y.UyeFotograf).FirstOrDefault();
            ViewBag.v3 = d3;
            var d4 = db.TBL_Uye.Where(k => k.Uyemail == x).Select(y => y.Uyekullanıcıadı).FirstOrDefault();
            ViewBag.v4 = d4;
            var d5 = db.TBL_Uye.Where(k => k.Uyemail == x).Select(y => y.UyeOkul).FirstOrDefault();
            ViewBag.v5 = d5;
            var d6 = db.TBL_Uye.Where(k => k.Uyemail == x).Select(y => y.Uyetelefon).FirstOrDefault();
            ViewBag.v6 = d6;
            var uyeid = db.TBL_Uye.Where(k => k.Uyemail == x).Select(y => y.Uyeid).FirstOrDefault();
            var d7 = db.TBL_Hareket.Where(k => k.Alanuye == uyeid).Count();
            ViewBag.v7 = d7;
            var d8 = db.TBL_Mesajlar.Where(k => k.Mesajalıcı == x).Count();
            ViewBag.v8 = d8;
            var d9 = db.TBL_DUYURULAR.Count();
            ViewBag.v9 = d9;
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TBL_Uye p)
        {
            var x = Session["Uyemail"].ToString();
            var uye = db.TBL_Uye.FirstOrDefault(k=>k.Uyemail == x);
            uye.Uyekullanıcısifre = p.Uyekullanıcısifre;
            uye.Uyead = p.Uyead;
            uye.Uyesoyad = p.Uyesoyad;
            uye.Uyetelefon = p.Uyetelefon;
            uye.UyeOkul = p.UyeOkul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            var uyemail = Session["Uyemail"].ToString();
            var x = db.TBL_Hareket.Where(k => k.islemdurum == true && k.TBL_Uye.Uyemail==uyemail).ToList();
            return View(x);
        }
        
        public ActionResult Duyurular()
        {
            var x = db.TBL_DUYURULAR.ToList();
            return View(x);
        }
        public ActionResult DuyuruDetay(int id)
        {
            var x = db.TBL_DUYURULAR.Find(id);
            var v1 = x.icerik;
            var v2 = x.Kategori;
            var v3 = Convert.ToDateTime( x.Tarih).ToString("dd/MM/yyyy");
            ViewBag.d1 = v1;
            ViewBag.d2 = v2;
            ViewBag.d3 = v3;
            return View(x);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); 
            return RedirectToAction("Index","Panelim");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var uyemail = (string)Session["Uyemail"];
            var id = db.TBL_Uye.Where(k => k.Uyemail == uyemail).Select(z => z.Uyeid).FirstOrDefault();
            var x = db.TBL_Uye.Find(id);
            return PartialView("Partial2",x);
        }
    }
}