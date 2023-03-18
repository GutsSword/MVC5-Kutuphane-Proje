using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Proje1.Models.Entity;

namespace MVC5_Proje1.Controllers
{
    public class KitapController : Controller
    {
        MV5_Proje1Entities db = new MV5_Proje1Entities();
        // GET: Kitap

        public ActionResult Index(string p)
        {
            var x = from k in db.TBL_Kitap select k;
            if(!string.IsNullOrEmpty(p))
            {
                x = x.Where(m => m.Kitapad.Contains(p));
            }
          //var x = db.TBL_Kitap.ToList();
            return View(x.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> x = (from i in db.TBL_Kategori.ToList()
                                      select new SelectListItem
                                      {
                                          Text = i.Ad,
                                          Value = i.Kategoriid.ToString()
                                      }).ToList();
            ViewBag.k = x;

            List<SelectListItem> yazar = (from i in db.TBL_Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.yazarad + ' ' + i.yazarsoyad,
                                              Value = i.Yazarid.ToString()
                                          }).ToList();
            ViewBag.yazar = yazar;

            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBL_Kitap p)
        {
            p.Durum = true;
            var kategori = db.TBL_Kategori.Where(x => x.Kategoriid == p.TBL_Kategori.Kategoriid).FirstOrDefault();
            var yazar = db.TBL_Yazar.Where(y => y.Yazarid == p.TBL_Yazar.Yazarid).FirstOrDefault();
            p.TBL_Kategori = kategori;
            p.TBL_Yazar = yazar;
            db.TBL_Kitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var x = db.TBL_Kitap.Find(id);
            db.TBL_Kitap.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KitapGetir(int id)
        {
            List<SelectListItem> x = (from i in db.TBL_Kategori.ToList()
                                      select new SelectListItem
                                      {
                                          Text = i.Ad,
                                          Value = i.Kategoriid.ToString()
                                      }).ToList();
            ViewBag.k = x;

            List<SelectListItem> yazar = (from i in db.TBL_Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.yazarad + ' ' + i.yazarsoyad,
                                              Value = i.Yazarid.ToString()
                                          }).ToList();
            ViewBag.yazar = yazar;

            var data = db.TBL_Kitap.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult KitapGuncelle(TBL_Kitap p)
        {

            var x = db.TBL_Kitap.Find(p.Kitapid);
            x.Kitapad = p.Kitapad;
            x.Basımyıl = p.Basımyıl;
            x.Kitapsayfa = p.Kitapsayfa;
            x.Yayınevi = p.Yayınevi;
            x.Durum = p.Durum;
            var ktg = db.TBL_Kategori.Where(k => k.Kategoriid == p.TBL_Kategori.Kategoriid).FirstOrDefault();
            var yzr = db.TBL_Yazar.Where(y => y.Yazarid == p.TBL_Yazar.Yazarid).FirstOrDefault();
            x.Kitapkategori = ktg.Kategoriid;
            x.Kitapyazar = yzr.Yazarid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
        
}