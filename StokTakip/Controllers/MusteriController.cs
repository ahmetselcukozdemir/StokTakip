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
        public ActionResult Index(string p)
        {
            //var values = db.Musteriler.ToList();
            var values = from d in db.Musteriler select d;
            if(!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.musteriAd.Contains(p));
            }
            return View(values.ToList());
            //return View(values);
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
            if(customer!=null)
            db.Musteriler.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult MusteriGetir(int id)
        {
            try
            {
                var customer = db.Musteriler.Find(id);
                return View("MusteriGetir", customer);
            }
            catch (Exception x)
            {

                throw x;
            }
         

        }
        public ActionResult Guncelle(Musteriler customer)
        {
            try
            {
                var m = db.Musteriler.Find(customer.musteriID);
                if (m != null)
                m.musteriAd = customer.musteriAd;
                m.musteriSoyad = customer.musteriSoyad;
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