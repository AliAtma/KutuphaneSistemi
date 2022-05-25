using AliHaydarAtma.Entites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AliHaydarAtma.MVC.Controllers.Api
{
    public class MusteriController : ApiController
    {
        private SatisContext db;
        public MusteriController()
        {
            db = new SatisContext();
        }

        [HttpGet]

        public IHttpActionResult GetMusteris()
        {
            var musteris = db.Musteri.Where(x => x.MusteriDurumu == true).ToList();
            return Ok(musteris);
        }

        [HttpGet]
        public IHttpActionResult GetMusteri(int id)
        {
            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();
            return Ok(musteri);

        }
        [HttpPost]
        public IHttpActionResult AddMusteri(Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Musteri.Add(pMusteri);
            db.SaveChanges();
            return Ok(pMusteri);
        }

        [HttpPut]
        public IHttpActionResult UpdateMusteri(int id, Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();

            musteri.MusteriAdi = pMusteri.MusteriAdi;
            musteri.MusteriSoyadi = pMusteri.MusteriSoyadi;
            musteri.DogumTarihi = pMusteri.DogumTarihi;
            musteri.MusteriDurumu = pMusteri.MusteriDurumu;
            db.SaveChanges();

            return Ok(musteri);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMusteri(int id)
        {
            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriId == id);
            if (musteri == null)
                return NotFound();
            db.Musteri.Remove(musteri);
            db.SaveChanges();

            return Ok();
        }
    }
}