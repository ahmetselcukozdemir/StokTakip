using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace StokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa =1)
        {
            //var values = db.Kategoriler.ToList();
            var values = db.Kategoriler.ToList().ToPagedList(sayfa, 5);
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
            if(category !=null)
            db.Kategoriler.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            try
            {
                var category = db.Kategoriler.Find(id);
                return View("KategoriGetir", category);
            }
            catch (Exception a)
            {

                throw a;
            }
         

        }
        public ActionResult Guncelle(Kategoriler category)
        {
            var ktg = db.Kategoriler.Find(category.kategoriID);
            if(ktg!=null)
            ktg.kategoriAd = category.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}