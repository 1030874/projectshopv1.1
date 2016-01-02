using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webServer.Controllers
{
    public class CatalogController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET: Catalog
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult TopSales()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }
    }
}