using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFramework;

namespace ÖğrenciNotMVC.Controllers
{
    public class NotlarController : Controller
    {
        DbMvcOkulEntities db=new DbMvcOkulEntities();
        // GET: Notlar
        public ActionResult Index()
        {
            var not=db.Tbl_Notlar.ToList();
            return View(not);
        }
    }
}