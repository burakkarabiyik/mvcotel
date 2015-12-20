using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OtelEleven.Models;
using System.IO;

namespace OtelEleven.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OdalarsController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Admin/Odalars
        public ActionResult Index()
        {
            return View(db.Resimler.ToList());
        }

        // GET: Admin/Odalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odalar odalar = db.Resimler.Find(id);
            if (odalar == null)
            {
                return HttpNotFound();
            }
            return View(odalar);
        }

        // GET: Admin/Odalars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Odalars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Foto1")] Odalar odalar, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    odalar.Foto1 = memoryStream.ToArray();
                }
                db.Resimler.Add(odalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odalar);
        }

        // GET: Admin/Odalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odalar odalar = db.Resimler.Find(id);
            if (odalar == null)
            {
                return HttpNotFound();
            }
            return View(odalar);
        }

        // POST: Admin/Odalars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Foto1")] Odalar odalar, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    odalar.Foto1 = memoryStream.ToArray();
                }

                db.Entry(odalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odalar);
        }

        // GET: Admin/Odalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odalar odalar = db.Resimler.Find(id);
            if (odalar == null)
            {
                return HttpNotFound();
            }
            return View(odalar);
        }

        // POST: Admin/Odalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Odalar odalar = db.Resimler.Find(id);
            db.Resimler.Remove(odalar);
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
