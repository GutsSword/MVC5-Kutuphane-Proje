using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;
namespace MVC5_Proje1.Controllers
{
    public class istatistikController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: istatistik
        public ActionResult Index()
        {
            var data1 = db.TBL_Uye.Count();
            var data2 = db.TBL_Kitap.Count();
            var data3 = db.TBL_Kitap.Where(x=>x.Durum==false).Count();
            var data4 = db.TBL_Cezalar.Sum(x=>x.para);
            ViewBag.viewdata1 = data1;
            ViewBag.viewdata2 = data2;
            ViewBag.viewdata3 = data3;
            ViewBag.viewdata4 = data4;           
            return View();
        }
        public ActionResult Linqkart()
        {
            var data1 = db.TBL_Kitap.Count();
            ViewBag.d1 = data1;
            var data2 = db.TBL_Uye.Count();
            ViewBag.d2 = data2;
            var data3 = db.TBL_Cezalar.Sum(x=>x.para);
            ViewBag.d3 = data3;
            var data4 = db.TBL_Kitap.Where(x => x.Durum == false).Count();
            ViewBag.d4 = data4;
            var data5 = db.TBL_Kategori.Count();
            ViewBag.d5 = data5;
            var data9 = db.TBL_Kitap.GroupBy(x => x.Yayınevi).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            ViewBag.d9 = data9;
            var data8 = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.d8 = data8;
            var data11 = db.TBL_ILETISIM.Count();
            ViewBag.d11 = data11;
            return View();
        }
    }
}