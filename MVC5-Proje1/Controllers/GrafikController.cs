using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models;


namespace MVC5_Proje1.Controllers
{
    public class GrafikController : Controller
    {

        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Güneş",
                sayi = 7
            });
            cs.Add(new Class1()
            {
                yayinevi = "Mars",
                sayi = 2
            });

            cs.Add(new Class1()
            {
                yayinevi = "Jupiter",
                sayi = 3
            });
            return cs;
        }
    }
}