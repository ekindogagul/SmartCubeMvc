using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SmartCubeMvc.Context;
using SmartCubeMvc.Models;

namespace SmartCubeMvc.Controllers
{

    public class SignupController : Controller
    {
        private SmartCubeContext db = new SmartCubeContext();

        [HttpPost]
        public ActionResult Index(string username, string password)
        {

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User(string username, string password)
        {
            Users user = new Users();

            user.username = username;
            user.password = password;

            db.Users.Add(user);
            db.SaveChanges();


            // return View("Index");
            return RedirectToAction("Index", "Home");
        }
    }
}
    