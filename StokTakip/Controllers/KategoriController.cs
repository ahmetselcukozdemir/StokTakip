using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;
namespace StokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.Kategoriler.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniKategori(Kategoriler category)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Kategoriler.Add(category);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var category = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var category = db.Kategoriler.Find(id);
            return View("KategoriGetir", category);

        }
        public ActionResult Guncelle(Kategoriler category)
        {
            var ktg = db.Kategoriler.Find(category.kategoriID);
            ktg.kategoriAd = category.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}