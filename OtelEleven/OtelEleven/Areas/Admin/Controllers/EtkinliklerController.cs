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
using System.Web.UI.WebControls;

namespace OtelEleven.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EtkinliklerController : Controller
    {
        private dbContext db = new dbContext();


        // GET: Admin/Etkinlikler
        public ActionResult Index()
        
        {
             
            return View(db.Etkinlik.ToList());
        }

        // GET: Admin/Etkinlikler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlikler etkinlikler = db.Etkinlik.Find(id);
            if (etkinlikler == null)
            {
                return HttpNotFound();
            }
            return View(etkinlikler);
        }

        // GET: Admin/Etkinlikler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Etkinlikler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EtkinlikAdi,Tarih,icerik,Foto")] Etkinlikler etkinlikler, HttpPostedFileBase file)
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
                    etkinlikler.Foto = memoryStream.ToArray();
                }

                db.Etkinlik.Add(etkinlikler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etkinlikler);
        }

        // GET: Admin/Etkinlikler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlikler etkinlikler = db.Etkinlik.Find(id);
            if (etkinlikler == null)
            {
                return HttpNotFound();
            }
            return View(etkinlikler);
        }

        // POST: Admin/Etkinlikler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EtkinlikAdi,Tarih,icerik,Foto")] Etkinlikler etkinlikler, HttpPostedFileBase file)
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
                    etkinlikler.Foto = memoryStream.ToArray();
                }

                db.Entry(etkinlikler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etkinlikler);
        }

        // GET: Admin/Etkinlikler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etkinlikler etkinlikler = db.Etkinlik.Find(id);
            if (etkinlikler == null)
            {
                return HttpNotFound();
            }
            return View(etkinlikler);
        }

        // POST: Admin/Etkinlikler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etkinlikler etkinlikler = db.Etkinlik.Find(id);
            db.Etkinlik.Remove(etkinlikler);
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
