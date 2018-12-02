using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SmartCubeMvc.Context;
using System.Data.Entity;
using SmartCubeMvc.Models;

namespace SmartCubeMvc.Controllers
{
    public class UserController : Controller
    {
        public SmartCubeContext db = new SmartCubeContext();
        // GET: User
        public ActionResult Index()
        {
           
            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];
            return View(db.Users.ToList()); 
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,username,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,username,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            ViewData["logLabel"] = "Log out";
            ViewData["username"] = (string)Session["username"];
            return RedirectToAction("Index");
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(string username, string password, string confirmPassword)
        {
            bool usernameAvailable = true;

            User newUser = new User();
            newUser.username = username;
            newUser.password = password;

            List<User> users = db.Users.ToList();

            foreach (User user in users)
            {
                if (user.username.Equals(username))
                {
                    usernameAvailable = false;
                    break;
                }
            }
            if (!usernameAvailable)
            {
                ViewData["message"] = "Username not available.";
                return View();
            }
            else
            {

                if (password.Length < 6)
                {
                    ViewData["message"] = "Password must be at least 6 characters.";
                    return View();
                }
                else if (password != confirmPassword)
                {
                    ViewData["message"] = "Passwords do not match.";
                    return View();
                }
                else
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool userFound = false;
            bool passwordCorrect = false;

            List<User> users = db.Users.ToList();

            foreach (User user in users)
            {
                if (username == user.username)
                {
                    userFound = true;
                    if (password == user.password)
                        passwordCorrect = true;

                    break;
                }
            }

            if (!userFound)
            {
                ViewData["message"] = "Incorrect username and/or password.";
                return View();
            }
            else if (!passwordCorrect)
            {
                ViewData["message"] = "Incorrect username and/or password.";
                return View();
            }
            else
            {
                if (username == "admin")
                {
                    Session["username"] = username;
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    Session["username"] = username;
                    return RedirectToAction("Home", "Product");
                }
            }
        }
    }
}
        
            