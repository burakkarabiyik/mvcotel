using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OtelEleven.Models;
using System.Data.Entity;
using System.Web.Security;
using Microsoft.AspNet.Identity; 
namespace OtelEleven.Areas.Admin.Controllers
{
        [Authorize(Roles="Admin")]
    public class kullanicilarController : Controller
    
    {
         

        // GET: Admin/kullanicilar
        OtelEleven.Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        public ActionResult Index()
        {

            
          
            return View(db.Users.ToList());
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var üye = db.Users.Where(i => i.Kullaniciadi == id).First();
            if (üye == null)
            {
                return HttpNotFound();
            }
            return View(üye);
        }

        [HttpPost] 
        public ActionResult Edit([Bind(Include = "Id,Ulke,Ad,Soyad,Kullaniciadi,Telno")] ApplicationUser userim)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(i => i.Kullaniciadi == userim.Kullaniciadi);
                user.First().Ulke = userim.Ulke;
                user.First().Ad = userim.Ad;
                user.First().Soyad = userim.Soyad;
                user.First().Telno = userim.Telno;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userim);
        }
    }
}