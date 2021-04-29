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
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        TaskRepository  tasks = new TaskRepository();
        

        
        [Route("tasks")]
        public IHttpActionResult Get()
        {
            return Ok(tasks.GetPendingPosts());
        }

        [Route("")]
        public IHttpActionResult Post()
        {
            
            return Ok();
        }
    }
}
