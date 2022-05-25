using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AliHaydarAtma.Entites.Model;

namespace AliHaydarAtma.MVC.Controllers
{
    public class KategoriController : Controller
    {
        SatisContext db = new SatisContext();
        // GET: Kategori
        public ActionResult Index()
        {
            List<Kategori> kategoriler = db.Kategori.Where(x => x.KategoriDurumu == true).ToList();
            return View(kategoriler);
        }

        public ActionResult Sil(int id)
        {
            Kategori ktgr = db.Kategori.Find(id);
            ktgr.KategoriDurumu = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kategori pktgr)
        {
            Kategori ktgr = new Kategori();
            ktgr.KategoriAciklama = pktgr.KategoriAciklama;
            ktgr.KategoriAdi = pktgr.KategoriAdi;
            ktgr.KategoriDurumu = true;

            db.Kategori.Add(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Kategori ktgr = db.Kategori.Find(id);
            return View(ktgr);
        }
        [HttpPost]
        public ActionResult Guncelle(Kategori pktgr)
        {
            Kategori ktgr = db.Kategori.Find(pktgr.KategoriId);
            ktgr.KategoriAdi = pktgr.KategoriAdi;
            ktgr.KategoriAciklama = pktgr.KategoriAciklama;
            ktgr.KategoriDurumu = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}