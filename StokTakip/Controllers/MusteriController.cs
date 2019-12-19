using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;
namespace StokTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.Musteriler.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Musteriler customer)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            db.Musteriler.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var customer = db.Musteriler.Find(id);
            db.Musteriler.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
       public ActionResult MusteriGetir(int id)
        {
            var customer = db.Musteriler.Find(id);
            return View("MusteriGetir",customer);

        }
        public ActionResult Guncelle(Musteriler customer)
        {
            var m = db.Musteriler.Find(customer.musteriID);
            m.musteriAd = customer.musteriAd;
            m.musteriSoyad = customer.musteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}