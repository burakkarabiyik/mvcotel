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
            ana.Yorum = ent.yorumlar.ToList();
            //if(ent.Slider.DefaultIfEmpty()!=null)
            //{
            //    return View();
            //}
            return View(ana);
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Etkinlikler()
        {
            
            return View(ent.Etkinlik.ToList());
        }
        public ActionResult Rezervasyon()
        {
            Rezerv rz = new Rezerv();
            rz.oda = ent.oda.Where(m => m.Dolumu== false).ToList();

            return View(rz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rezervasyon([Bind(Include = "Id,Cikis,Giris,Odano")] Rezervasyon rez)
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
            var rez = ent.Rezervasyon.Where(i=>i.Cikis<DateTime.Now).ToList();
            Oda oda;
            foreach (var item in rez)
            {
                oda = ent.oda.Find(item.Odano);
                oda.Dolumu = false;
            }
            ent.SaveChanges();
        }
        public ActionResult Odalar()
        {
            return View();
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