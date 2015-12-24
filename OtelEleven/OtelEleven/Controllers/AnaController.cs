using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelEleven.Models;
using System.Globalization;

namespace OtelEleven.Controllers
{
    public class AnaController : Controller
    {
        dbContext ent = new dbContext();
        public ActionResult Intro()
        {
            rezervasyonkontrol();
            return View();

        }
        public ActionResult Anasayfa()
        {
            Anasayfa ana = new Models.Anasayfa();
            ana.Slider = ent.Slider.ToList();
            ana.Yorum = ent.yorumlar.OrderByDescending(m=>m.Id).Take(5).ToList();
            
            return View(ana);
        }

        public ActionResult Yorumyap()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Yorumyap([Bind(Include = "Id,kullaniciadi,yorum")] Yorumlar yorumlar)
        {
            dbContext db = new dbContext();
            if (ModelState.IsValid)
            {
                db.yorumlar.Add(yorumlar);
                db.SaveChanges();
                return RedirectToAction("Anasayfa");
            }

            return View(yorumlar);
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Etkinlikler()
        {
            
            return View(ent.Etkinlik.ToList());
        }
        [Authorize]
        public ActionResult Rezervasyon()
        {
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rezervasyon([Bind(Include = "Id,Cikis,Giris,hangikullanici,Odano")] Rezervasyon rez)
        {
            if (ModelState.IsValid)
            {
                Oda odam=ent.oda.Find(rez.Odano);
                odam.Dolumu = true;
                ent.Rezervasyon.Add(rez);
                ent.SaveChanges();
                return RedirectToAction("Anasayfa");
            }

            return View(rez);
        }
        public void rezervasyonkontrol()
        {
            if (ent.Rezervasyon.Count() > 0)
            {
                var rez = ent.Rezervasyon.Where(i => i.Cikis < DateTime.Now).ToList();
                Oda oda;
                foreach (var item in rez)
                {
                    oda = ent.oda.Find(item.Odano);
                    oda.Dolumu = false;
                }
                ent.SaveChanges();
            }
        }
        public ActionResult Odalar()
        {
            dbContext db = new dbContext();
            var odalar = db.Resimler.ToList();
            return View(odalar);
        }
        public ActionResult Ekstralar()
        {
            return View(ent.Kampanya.ToList());
        }
        public ActionResult Details(int? id)
        {

            Kampanya kmp = ent.Kampanya.Find(id);
            kmp.oda = ent.oda.Find(kmp.OdaNo);
            return View(kmp);
        }
        public ActionResult ChangeCulture(string lang, string returnUrl) { Session["Culture"] = new CultureInfo(lang); return Redirect(returnUrl); }
    }
}