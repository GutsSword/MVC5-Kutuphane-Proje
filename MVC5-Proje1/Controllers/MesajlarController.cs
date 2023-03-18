using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;

namespace MVC5_Proje1.Controllers
{
    public class MesajlarController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Mesajlar
        public ActionResult Index()
        {
            var uyemail = Session["Uyemail"].ToString();
            var x = db.TBL_Mesajlar.Where(k => k.Mesajalıcı == uyemail.ToString()).ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBL_Mesajlar p)
        {
            var uyemail = Session["Uyemail"].ToString(); 
            p.Mesajgonderen = uyemail.ToString();
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_Mesajlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesaj");
        }
        public ActionResult GidenMesaj()
        {
            var uyemail = Session["Uyemail"].ToString();
            var x = db.TBL_Mesajlar.Where(k => k.Mesajgonderen == uyemail).ToList();
            return View(x);
        }
        public ActionResult MesajDetay(int id)
        {
            var uyemail = Session["Uyemail"].ToString();
            //var x = db.TBL_Mesajlar.Where(k=>k.Mesajalıcı==uyemail && k.Mesajid==id).ToList();

            var data1 = db.TBL_Mesajlar.Where(k => k.Mesajid == id).Select(z => z.Mesajkonu).FirstOrDefault();
            ViewBag.v1 = data1;
            var data2 = db.TBL_Mesajlar.Where(k => k.Mesajid == id).Select(z => z.Mesajgonderen).FirstOrDefault();
            ViewBag.v2 = data2;
            var data3 = db.TBL_Mesajlar.Where(k => k.Mesajid == id).Select(z => z.Icerik).FirstOrDefault();
            ViewBag.v3 = data3;
            var data4 = db.TBL_Mesajlar.Where(k => k.Mesajid == id).Select(z => z.Tarih).FirstOrDefault();
            ViewBag.v4 = data4;
            return View();
        }
        public ActionResult Partial1()
        {
            var uyemail = Session["Uyemail"].ToString();
            var gelensayisi = db.TBL_Mesajlar.Where(k => k.Mesajalıcı == uyemail).Count();
            ViewBag.v1 = gelensayisi;
            var gidensayisi = db.TBL_Mesajlar.Where(k => k.Mesajgonderen == uyemail).Count();
            ViewBag.v2 = gidensayisi;
            return PartialView();
        }
    }
}