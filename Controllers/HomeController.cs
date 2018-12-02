using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCubeMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["logLabel"] = "Login";
            return View();
           
        }
        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";
            return View();

        }
        public ActionResult Product()
        {
            ViewBag.Message = "Your product page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

    }
}