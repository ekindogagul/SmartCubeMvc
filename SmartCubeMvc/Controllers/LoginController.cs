using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCubeMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult User(string username, string password)
        {


            ViewData["message"] = "Error will go here";


            // return View("Index");
            return RedirectToAction("Index", "Home");
        }
    }
}