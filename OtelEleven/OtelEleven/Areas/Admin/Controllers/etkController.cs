using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelEleven.Areas.Admin.Controllers
{
    public class etkController : Controller
    {
        // GET: Admin/etk
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}