using AliHaydarAtma.Entites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AliHaydarAtma.MVC.Controllers.Api
{
    public class UrunController : ApiController
    {
        private SatisContext db;
        public UrunController()
        {
            db = new SatisContext();
        }

        [HttpGet]

        public IHttpActionResult GetUruns()
        {
            var uruns = db.Urun.Where(x => x.UrunDurumu == true).ToList();
            return Ok(uruns);
        }

        [HttpGet]
        public IHttpActionResult GetUrun(int id)
        {
            var urun = db.Urun.SingleOrDefault(x => x.UrunId == id);
            if (urun == null)
                return NotFound();
            return Ok(urun);

        }
        [HttpPost]
        public IHttpActionResult AddUrun(Urun pUrun)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Urun.Add(pUrun);
            db.SaveChanges();
            return Ok(pUrun);
        }

        [HttpPut]
        public IHttpActionResult UpdateUrun(int id, Urun pUrun)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var urun = db.Urun.SingleOrDefault(x => x.UrunId == id);
            if (urun == null)
                return NotFound();

            urun.UrunAdi = pUrun.UrunAdi;
            urun.UrunKodu = pUrun.UrunKodu;
            urun.UrunFiyat = pUrun.UrunFiyat;
            urun.UrunStok = pUrun.UrunStok;
            urun.UrunDurumu = pUrun.UrunDurumu;
            db.SaveChanges();

            return Ok(urun);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUrun(int id)
        {
            var urun = db.Urun.SingleOrDefault(x => x.UrunId == id);
            if (urun == null)
                return NotFound();
            db.Urun.Remove(urun);
            db.SaveChanges();

            return Ok();
        }
    }
}
