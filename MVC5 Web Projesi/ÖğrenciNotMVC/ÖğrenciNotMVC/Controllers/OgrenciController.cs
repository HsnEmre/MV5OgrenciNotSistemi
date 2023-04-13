using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFramework;

namespace ÖğrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {

        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogr = db.Tbl_Ogrencıler.ToList();
            return View(ogr);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            //Linq sorgusuyla veri tabanından veri çekme
            List<SelectListItem> degerler = (from x in db.Tbl_Kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KULUAD,
                                                 Value = x.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;


            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(Tbl_Ogrencıler p)
        {
            //seçilen ıd ye göre atama işlemi

            var klp = db.Tbl_Kulupler.Where(m => m.KULUPID == p.Tbl_Kulupler.KULUPID).FirstOrDefault();
            p.Tbl_Kulupler = klp;

            db.Tbl_Ogrencıler.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}