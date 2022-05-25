using AliHaydarAtma.Entites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AliHaydarAtma.MVC.Controllers 
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Personel pPersonel)
        {
            using (SatisContext db = new SatisContext())
            {
                Personel personel = db.Personel.AsNoTracking().Where(x => x.PersonelEmail == pPersonel.PersonelEmail && x.PersonelParola == pPersonel.PersonelParola).FirstOrDefault();

                if (personel != null)
                {
                    FormsAuthentication.SetAuthCookie(personel.PersonelEmail, false);
                    // Sisteme login olunuldu demektir.
                    Session["PersonelId"] = personel.PersonelId;
                    Session["Personeli"] = personel.PersonelAdi + " " + personel.PersonelSoyadi;
                    return RedirectToAction("Index", "Kategori");
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}