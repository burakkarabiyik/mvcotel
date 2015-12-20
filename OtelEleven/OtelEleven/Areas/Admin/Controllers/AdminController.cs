using Microsoft.AspNet.Identity;
using OtelEleven.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OtelEleven.Models;

namespace OtelEleven.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin

        private dbContext db = new dbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RezervasyonDüzenle()
        {
            return View(db.Rezervasyon.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Giris,Cikis,Odano")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervasyon);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            if (rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(rezervasyon);
        }


        // POST: Admin/Rezervasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {   Rezervasyon rezervasyon = db.Rezervasyon.Find(id);
            db.Rezervasyon.Remove(rezervasyon);

            Oda oda = db.oda.Where(i=>i.OdaNo==rezervasyon.Odano).First();
            oda.Dolumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       


         
    }
}