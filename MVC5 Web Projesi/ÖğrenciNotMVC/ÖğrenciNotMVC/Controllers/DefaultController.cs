using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFramework;


namespace ÖğrenciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();//bu nesne tablolarıma ulaşmak için kullanacağım nesnem.
        public ActionResult Index()
        {
            var dersler = db.Tbl_Dersler.ToList();

            return View(dersler);//gerriye dersler adlı değişkenimi döndür
        }
        [HttpGet]
        public ActionResult Yeniders()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(Tbl_Dersler p)
        {
            db.Tbl_Dersler.Add(p);//parametreden gelen değeri eklicek
            db.SaveChanges();//executenonquery gibi veri tabanına eklerdeğişiklikleri
            return View();
        }
    }
}