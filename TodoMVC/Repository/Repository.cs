using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoMVC.Models;

namespace TodoMVC.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext context;
        public Repository()
        {
            this.context = new DataContext();
        }



        public List<T> GetAll()
        {

            return context.Set<T>().ToList();
        }


        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }



        public void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        

            public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}