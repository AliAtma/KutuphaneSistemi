using AliHaydarAtma.Entites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AliHaydarAtma.MVC.Controllers.Api
{
    public class SepetController : ApiController
    {
        private SatisContext db;
        public SepetController()
        {
            db = new SatisContext();
        }

        [HttpGet]

        public IHttpActionResult GetSepets()
        {
            var sepets = db.Sepet.Where(x => x.SepetDurumu == true).ToList();
            return Ok(sepets);
        }

        [HttpGet]
        public IHttpActionResult GetSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();
            return Ok(sepet);

        }
        [HttpPost]
        public IHttpActionResult AddSepet(Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Sepet.Add(pSepet);
            db.SaveChanges();
            return Ok(pSepet);
        }

        [HttpPut]
        public IHttpActionResult UpdateSepet(int id, Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();

            sepet.SepetAdet = pSepet.SepetAdet;
            sepet.SepetToplam = pSepet.SepetToplam;
            sepet.SepetDurumu = pSepet.SepetDurumu;
            sepet.Musteri.MusteriAdi = pSepet.Musteri.MusteriAdi;
            sepet.Urun.UrunAdi = pSepet.Urun.UrunAdi;
            db.SaveChanges();

            return Ok(sepet);
        }

        [HttpDelete]
        public IHttpActionResult DeleteSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetId == id);
            if (sepet == null)
                return NotFound();
            db.Sepet.Remove(sepet);
            db.SaveChanges();

            return Ok();
        }
    }
}
