using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;

namespace MVC5_Proje1.Controllers
{
    public class islemController : Controller
    {
        MV5_Proje1Entities db =  new MV5_Proje1Entities();
        // GET: islem
        public ActionResult Index()
        {
            var x = db.TBL_Hareket.Where(k => k.islemdurum == true).ToList();
            return View(x);
        }
    }
}