using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelEleven.Controllers
{
    public class YöneticiController : Controller
    {
        // GET: Yönetici
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RezervasyonDüzenle()
        {
            return View();
        }
        public ActionResult Üyekontrol()
        {
            return View();
        }
        public ActionResult EtkinlikKontrol()
        {
            return View();
        }
        public ActionResult IletisimDuzenle()
        {
            return View();
        }
        public ActionResult PaketDüzenle()
        {
            return View();
        }
        public ActionResult OdaResimDüzenle()
        {
            return View();
        }
    }
}