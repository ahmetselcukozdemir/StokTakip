﻿using System;
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

            db.Kategoriler.Add(category);
            db.SaveChanges();
            return View();
        }
    }
}