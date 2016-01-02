using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using webServer.Models;
using System.Web.Security;


namespace webServer.Controllers
{
    public class UIController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            DatabaseConnection db = new DatabaseConnection();
            
            ViewBag.Title = "Home Page";

            ViewBag.Username = User.Identity.Name;

            var test = db.Customers.ToList();

            ViewBag.List = test;

            return View();
        }



       
    }
}
