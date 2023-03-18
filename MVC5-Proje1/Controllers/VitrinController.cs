using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
using MVC5_Proje1.Models.Sınıflarım;

namespace MVC5_Proje1.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Vitrin
        [HttpGet]
        
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.data1 = db.TBL_Kitap.ToList();
            cs.data2 = db.TBL_Hakkımızda.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBL_ILETISIM p)
        {
            db.TBL_ILETISIM.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}