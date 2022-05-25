using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AliHaydarAtma.Entites.Model;

namespace AliHaydarAtma.MVC.Controllers
{
    public class UrunController : Controller
    {
        SatisContext db = new SatisContext();
        // GET: Urun
        public ActionResult Index(string aranacakKelime)
        {
            var urunler = db.Urun.Include("Kategori").Where(x => x.UrunDurumu == true);
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                urunler = urunler.Where(x => x.UrunAdi.Contains(aranacakKelime));
            }
            

            return View(urunler.ToList());
        }


        public ActionResult Sil(int id)
        {
            Urun ktp = db.Urun.Find(id);
            ktp.UrunDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Urun urn = db.Urun.Find(id);

            List<SelectListItem> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true)
                .Select(s => new SelectListItem
                {
                    Value = s.KategoriId.ToString(),
                    Text = s.KategoriAdi
                }).ToList();
            ViewBag.Kategoriler = kategoriler;
            return View(urn);
        }

        [HttpPost]
        public ActionResult Guncelle(Urun pUrun)
        {
            Urun urn = db.Urun.Find(pUrun.UrunId);
            urn.UrunAdi = pUrun.UrunAdi;
            urn.UrunKodu = pUrun.UrunKodu;
            urn.UrunFiyat = pUrun.UrunFiyat;
            urn.UrunStok = pUrun.UrunStok;
            urn.Kategori = db.Kategori.Find(pUrun.Kategori.KategoriId);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] // Sayfa yüklendiğinde çalışacak

        public ActionResult Ekle()
        {

            List<SelectListItem> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true)
                .Select(s => new SelectListItem
                {
                    Value = s.KategoriId.ToString(),
                    Text = s.KategoriAdi
                }).ToList();

            ViewBag.Kategoriler = kategoriler;
            return View();
        }

        [HttpPost] // Sayfa içerisinde bir yerde sayfayı post edildiğinde çalışacak
        public ActionResult Ekle(Urun pUrun)
        {
            pUrun.Kategori = db.Kategori.Find(pUrun.KategoriId);
            pUrun.UrunDurumu = true;
            db.Urun.Add(pUrun);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}