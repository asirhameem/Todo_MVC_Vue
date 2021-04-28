using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMVC.Models;

namespace TodoMVC.Repository
{
    public class UserRepository : Repository<User>
    {
        public User GetUserByEmail(string email)
        {
            return this.context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

    }
}