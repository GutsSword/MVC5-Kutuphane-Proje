using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
namespace MVC5_Proje1.Controllers
{
    [AllowAnonymous]
    public class KayitController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Kayıt
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TBL_Uye p)
        {
            if(!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBL_Uye.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}