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
        [ValidateAntiForgeryToken]
        
        public ActionResult Index(User user)
        {
            Session.Clear();

            var userInfo = users.GetUserByEmail(user.Email);
            if(userInfo == null)
            {
                return RedirectToAction("Index");
            }
            else if( userInfo.Email == user.Email && userInfo.Password == user.Password)
            {
                Session["Email"] = userInfo.Name;
                Session["Id"] = userInfo.Id;
                return RedirectToAction("AllTasks");
            }
            else
            {
                return View("Index");
            }
            

        }
    }
}