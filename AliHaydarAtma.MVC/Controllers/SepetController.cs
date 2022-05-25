using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AliHaydarAtma.Entites.Model;
using System.Data.Entity;

namespace AliHaydarAtma.MVC.Controllers
{
    public class SepetController : Controller
    {
        SatisContext db = new SatisContext();
        // GET: Sepet
        public ActionResult Index()
        {
            List<Sepet> sepetler = db.Sepet.Include(x=> x.Urun).ToList();
            return View(sepetler);
        }

        public ActionResult Sil(int id)
        {
            Sepet spt = db.Sepet.Find(id);
            db.Sepet.Remove(spt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> musteriler = db.Musteri.AsNoTracking().Where(x=>x.MusteriDurumu == true)
                .Select(s=> new SelectListItem
                {
                    Value = s.MusteriId.ToString(),
                    Text = s.MusteriAdi + " " + s.MusteriSoyadi
                }).ToList();

            List<SelectListItem> urunler = db.Urun.AsNoTracking().Where(x => x.UrunDurumu == true)
                .Select(s => new SelectListItem
                {
                    Value = s.UrunId.ToString(),
                    Text = s.UrunAdi
                }).ToList();

            ViewBag.Musteriler = musteriler;
            ViewBag.Urunler = urunler;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Sepet pSepet)
        {
            pSepet.Urun = db.Urun.Find(pSepet.UrunId);
            pSepet.Musteri = db.Musteri.Find(pSepet.MusteriId);
            pSepet.SepetToplam = pSepet.Urun.UrunFiyat * pSepet.SepetAdet;
            pSepet.Urun.UrunStok -= pSepet.SepetAdet;
            pSepet.SepetDurumu = true;
            db.Sepet.Add(pSepet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Sepet spt = db.Sepet.Find(id);

            List<SelectListItem> urunler = db.Urun.AsNoTracking().Where(x => x.UrunDurumu == true)
                .Select(s => new SelectListItem
                {
                    Value = s.UrunId.ToString(),
                    Text = s.UrunAdi
                }).ToList();

             List<SelectListItem> musteriler = db.Musteri.AsNoTracking().Where(x => x.MusteriDurumu == true)
                .Select(s => new SelectListItem
                {
                    Value = s.MusteriId.ToString(),
                    Text = s.MusteriAdi
                }).ToList();
            ViewBag.Kategoriler = musteriler;
            ViewBag.Musteriler = musteriler;
            ViewBag.Urunler = urunler;
            return View(spt);
        }

        [HttpPost]
        public ActionResult Guncelle(Sepet pSepet)
        {
            Sepet spt = db.Sepet.Find(pSepet.SepetId);
            spt.Musteri.MusteriAdi = pSepet.Musteri.MusteriAdi;
            spt.Urun.UrunAdi = pSepet.Urun.UrunAdi;
            spt.SepetAdet = pSepet.SepetAdet;
            spt.Urun = db.Urun.Find(pSepet.Urun.UrunId);
            spt.Musteri = db.Musteri.Find(pSepet.Musteri.MusteriAdi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}