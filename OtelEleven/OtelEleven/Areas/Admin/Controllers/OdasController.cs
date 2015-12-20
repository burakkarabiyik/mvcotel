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
    public class OdasController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Admin/Odas
        public ActionResult Index()
        {
            return View(db.oda.ToList());
        }

        // GET: Admin/Odas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda oda = db.oda.Find(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        // GET: Admin/Odas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Odas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OdaNo,Id,kackisi,Vip,Dolumu,Ucret")] Oda oda)
        {
            if (ModelState.IsValid)
            {
                db.oda.Add(oda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oda);
        }

        // GET: Admin/Odas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda oda = db.oda.Find(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        // POST: Admin/Odas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OdaNo,Id,kackisi,Vip,Dolumu,Ucret")] Oda oda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oda);
        }

        // GET: Admin/Odas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oda oda = db.oda.Find(id);
            if (oda == null)
            {
                return HttpNotFound();
            }
            return View(oda);
        }

        // POST: Admin/Odas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oda oda = db.oda.Find(id);
            db.oda.Remove(oda);
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
