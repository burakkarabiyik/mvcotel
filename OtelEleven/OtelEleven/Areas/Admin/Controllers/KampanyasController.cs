using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OtelEleven.Models;

namespace OtelEleven.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KampanyasController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Admin/Kampanyas
        public ActionResult Index()
        {
            var kampanya = db.Kampanya.Include(k => k.oda);
            return View(kampanya.ToList());
        }

        // GET: Admin/Kampanyas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanya.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            return View(kampanya);
        }

        // GET: Admin/Kampanyas/Create
        public ActionResult Create()
        {
            ViewBag.OdaNo = new SelectList(db.oda, "OdaNo", "OdaNo");
            return View();
        }

        // POST: Admin/Kampanyas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OdaNo,Ad,Indirim,Baslangic,Bitis")] Kampanya kampanya)
        {
            if (ModelState.IsValid)
            {
                db.Kampanya.Add(kampanya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OdaNo = new SelectList(db.oda, "OdaNo", "OdaNo", kampanya.OdaNo);
            return View(kampanya);
        }

        // GET: Admin/Kampanyas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanya.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            ViewBag.OdaNo = new SelectList(db.oda, "OdaNo", "OdaNo", kampanya.OdaNo);
            return View(kampanya);
        }

        // POST: Admin/Kampanyas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OdaNo,Ad,Indirim,Baslangic,Bitis")] Kampanya kampanya)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kampanya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OdaNo = new SelectList(db.oda, "OdaNo", "OdaNo", kampanya.OdaNo);
            return View(kampanya);
        }

        // GET: Admin/Kampanyas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanya.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            return View(kampanya);
        }

        // POST: Admin/Kampanyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kampanya kampanya = db.Kampanya.Find(id);
            db.Kampanya.Remove(kampanya);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
