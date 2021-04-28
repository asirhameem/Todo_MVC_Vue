using TodoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoMVC.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
            //Database.SetInitializer<DataContext>(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }
        virtual public DbSet<User> Users { get; set; }

        virtual public DbSet<Task> Tasks { get; set; }

    }

}