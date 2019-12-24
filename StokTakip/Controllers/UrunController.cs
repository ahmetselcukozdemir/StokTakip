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
            b => new SelectListItem { Value = b.kategoriID.ToString(), Text = b.kategoriAd });
            ViewData["basetype"] = basetypes;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler products)
        {
            if (!ModelState.IsValid)
            {
                return View("UrunEkle");
            }
            var category = db.Kategoriler.Where(m => m.kategoriID == products.Kategoriler.kategoriID).FirstOrDefault();
            products.Kategoriler = category;
            db.Urunler.Add(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var product = db.Urunler.Find(id);
            if(product!=null)
            db.Urunler.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunGetir(int id)
        {
            var product = db.Urunler.Find(id);
            if (product != null)
            {
                IEnumerable<SelectListItem> basetypes = db.Kategoriler.Select(
               b => new SelectListItem { Value = b.kategoriID.ToString(), Text = b.kategoriAd });
                ViewData["basetype"] = basetypes;
            }

            return View("UrunGetir", product);
        }

        public ActionResult Guncelle(Urunler p)
        {
            try
            {
                var urun = db.Urunler.Find(p.urunID);
                if(urun!=null)
                urun.urunAd = p.urunAd;
                urun.urunMarka = p.urunMarka;
                urun.urunStok = p.urunStok;
                urun.urunFiyat = p.urunFiyat;

                //pr.urunKategori = product.urunKategori;
                var category = db.Kategoriler.Where(m => m.kategoriID == p.Kategoriler.kategoriID).FirstOrDefault();
                urun.urunKategori = category.kategoriID;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}