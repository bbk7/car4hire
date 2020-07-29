using Car4Hire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Car4Hire.Controllers
{
    public class HomeController : Controller
    {
        private c4hDBEntities db = new c4hDBEntities();
        public ActionResult Index()
        {
            return View(db.Car.ToList());
            //return View();
        }
        public ActionResult Confirmation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}