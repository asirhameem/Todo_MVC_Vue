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

        [HttpGet]
        public ActionResult PendingTasks()
        {
            List<Task> pendings = tasks.PendingTask();
            return View(pendings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Login Controller
        public ActionResult Index(User user)
        {
            Session.Clear();

            var userInfo = users.GetUserByEmail(user.Email);
            if(userInfo == null)
            {
                return RedirectToAction("Index");
            }
            else if( userInfo.Email == user.Email && userInfo.Password == user.Password && userInfo.Type == "Admin")
            {
               
                return RedirectToAction("AllTasks");
            }
            else if (userInfo.Email == user.Email && userInfo.Password == user.Password && userInfo.Type == "Regular")
            {
                
                return RedirectToAction("PendingTasks");
            }
            else
            {
                TempData["Error"] = "User does not exist";
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult EditPending(int id)
        {
            var taskEdit = tasks.GetByID(id);
            taskEdit.TaskStatus = "Done";
            tasks.Edit(taskEdit);
            return RedirectToAction("PendingTasks");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var taskEdit = tasks.GetByID(id);
            taskEdit.TaskStatus = "Done";
            tasks.Edit(taskEdit);
            return RedirectToAction("AllTasks");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            tasks.Delete(id);
            return RedirectToAction("AllTasks");
        }

        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(Task task)
        {
            tasks.Insert(task);
            return RedirectToAction("AllTasks");
        }

    }
}