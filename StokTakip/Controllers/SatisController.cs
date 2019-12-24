using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;
namespace StokTakip.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(Satislar sales)
        {
            db.Satislar.Add(sales);
            db.SaveChanges();
            return View("Index");
        }
    }
}