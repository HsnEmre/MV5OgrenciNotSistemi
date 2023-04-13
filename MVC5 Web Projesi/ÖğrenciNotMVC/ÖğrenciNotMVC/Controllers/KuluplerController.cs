using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFramework;

namespace ÖğrenciNotMVC.Controllers
{
    public class KuluplerController : Controller
    {

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulupler
        public ActionResult Index()
        {
            var kulupler = db.Tbl_Kulupler.ToList();

            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(Tbl_Kulupler p)
        {
            db.Tbl_Kulupler.Add(p);
            db.SaveChanges();
            return View();
        }

    }
}