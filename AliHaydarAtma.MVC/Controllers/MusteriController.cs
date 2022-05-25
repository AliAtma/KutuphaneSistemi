using AliHaydarAtma.Entites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AliHaydarAtma.MVC.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        SatisContext db = new SatisContext();
        public ActionResult Index(string musteriAdi, int page=1)
        {
            var musteriler = db.Musteri.AsNoTracking().Where(x => x.MusteriDurumu == true || x.MusteriDurumu == false);
            if (!string.IsNullOrEmpty(musteriAdi))
            {
                musteriler = musteriler.Where(x => x.MusteriAdi.Contains(musteriAdi) || x.MusteriSoyadi.Contains(musteriAdi));
            }


            return View(musteriler.ToList());
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Musteri pMusteri)
        {
            pMusteri.MusteriDurumu = true;
            db.Musteri.Add(pMusteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            db.Musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            return View(musteri);
        }
        [HttpPost]
        public ActionResult Guncelle(Musteri pMusteri)
        {
            Musteri musteri = db.Musteri.Find(pMusteri.MusteriId);
            musteri.MusteriAdi = pMusteri.MusteriAdi;
            musteri.MusteriSoyadi = pMusteri.MusteriSoyadi;
            musteri.Cinsiyet = pMusteri.Cinsiyet;
            musteri.DogumTarihi = pMusteri.DogumTarihi;
            musteri.MusteriDurumu = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}