using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoMVC.Repository
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();
    }
}
