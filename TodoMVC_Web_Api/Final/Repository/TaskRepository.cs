using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    public class TaskRepository : Repository<Task>
    {
        public List<Task> GetPendingPosts()
        {
            return this.context.Tasks.Where(x => x.TaskStatus == "Pending").ToList();
        }

        
    }
}