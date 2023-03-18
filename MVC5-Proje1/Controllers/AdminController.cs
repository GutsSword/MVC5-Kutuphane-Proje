using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5_Proje1.Models.Entity;

namespace MVC5_Proje1.Controllers
{   
    [AllowAnonymous]
    public class AdminController : Controller
    {
        MV5_Proje1Entities db= new MV5_Proje1Entities();
        // GET: Admin
        
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(TBL_Admin p)
        {
            var x = db.TBL_Admin.FirstOrDefault(k => k.Kullanici == p.Kullanici && k.Sifre == p.Sifre);
            if(x != null)
            {
                FormsAuthentication.SetAuthCookie(x.Kullanici, false);
                Session["Kullanici"] = x.Kullanici.ToString();
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}