using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;
using TodoMVC.Repository;

namespace TodoMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        TaskRepository tasks = new TaskRepository();
        UserRepository users = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }


        
        [HttpGet]
        public ActionResult AllTasks()
        {
            List<Task> alltasks =  tasks.GetAll();
            return View(alltasks);
        }

        [HttpPost]
        public ActionResult Login(string email)
        {
            Session.Clear();

            var userInfo = users.GetUserByEmail(email);
            if(userInfo == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AllTasks");
            }
            /*return View(userInfo);*/

            /* var user = user.
             if (ModelState.IsValid)
             {
                 if (logins == null)
                 {
                     TempData["Messege"] = "Username or Password is incorrect";


                     return View("Login", u);
                 }
                 else
                 {
                     TempData["Messege"] = null;
                     if (logins.Type == "Instructor")
                     {
                         Session["uname"] = logins.Name;
                         Session["id"] = logins.Id;
                         return RedirectToAction("Index");
                     }
                     else if (logins.Type == "Student")
                     {
                         Session["uname"] = logins.Name;
                         Session["id"] = logins.Id;
                         return RedirectToAction("Index");
                     }
                     else if (logins.Type == "Admin")
                     {
                         Session["uname"] = logins.Name;
                         return RedirectToAction("CourseDetails", "Admin");
                     }

                 }

             }
             */


        }
    }
}