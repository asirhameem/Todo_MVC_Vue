using Final.Models;
using Final.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final.Controllers
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        TaskRepository tasks = new TaskRepository();

        [Route("alltasks", Name = "GetAllTasks")]
        public IHttpActionResult Get()
        {
            return Ok(tasks.GetAll());
        }



        [Route("create")]
        public IHttpActionResult Post(Task task)
        {
            tasks.Insert(task);
            string url = Url.Link("GetAllTasks", new { id = task.Id });
            return Created(url, task);
        }

        [Route("task/{id}", Name = "GetAllTasks")]
        public IHttpActionResult Get(int id)
        {
            return Ok(tasks.GetAll());
        }

        [Route("edit/{id}")]
        public IHttpActionResult Put([FromBody]Task task, [FromUri]int id)
        {
            task.Id = id;
            tasks.Edit(task);
            return Ok(task);
        }
    }
}
