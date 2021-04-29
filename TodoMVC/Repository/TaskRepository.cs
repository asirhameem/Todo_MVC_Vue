using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMVC.Models;

namespace TodoMVC.Repository
{
    public class TaskRepository : Repository<Task>
    {
        public void Delete(int id)
        {
            var task = GetByID(id);
            this.context.Tasks.Remove(task);
            context.SaveChanges();

        }

        public List<Task> PendingTask()
        {
            return this.context.Tasks.Where(x => x.TaskStatus == "Pending").ToList();
        }
    }
}