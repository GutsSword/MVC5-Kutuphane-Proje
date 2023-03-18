using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
using System.Web.Security;

namespace MVC5_Proje1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBL_Uye p )
        {
            var datax = db.TBL_Uye.FirstOrDefault(x=>x.Uyemail==p.Uyemail &&
            x.Uyekullanıcısifre==p.Uyekullanıcısifre);
            if(datax!=null)
            {
                FormsAuthentication.SetAuthCookie(datax.Uyemail, false);
                Session["Uyemail"] = datax.Uyemail.ToString();
                //TempData["Uyead"] = datax.Uyead.ToString();
                //TempData["Uyesoyad"] = datax.Uyesoyad.ToString();
                //TempData["UyeOkul"] = datax.UyeOkul.ToString();
                //TempData["UyeTelefon"] = datax.Uyetelefon.ToString();
                //TempData["UyeFoto"] = datax.UyeFotograf.ToString();
                //TempData["Uyeid"] = datax.Uyeid.ToString();
                //TempData["Uyesifre"] = datax.Uyekullanıcısifre.ToString();

                return RedirectToAction("Index","Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}