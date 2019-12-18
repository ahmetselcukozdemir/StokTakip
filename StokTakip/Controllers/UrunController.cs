using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;
namespace StokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.Urunler.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            IEnumerable<SelectListItem> basetypes = db.Kategoriler.Select(
      b => new SelectListItem { Value = b.kategoriID.ToString(), Text = b.kategoriAd});
            ViewData["basetype"] = basetypes;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler products)
        {
            var category = db.Kategoriler.Where(m => m.kategoriID == products.Kategoriler.kategoriID).FirstOrDefault();
            products.Kategoriler = category;
            db.Urunler.Add(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var product = db.Urunler.Find(id);
            db.Urunler.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}