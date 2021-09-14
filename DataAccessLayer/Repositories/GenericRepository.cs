using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IEntityRepository<T> where T : class
    {
        public void Add(T entity)
        {
            using var context = new Context();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var context = new Context();
            context.Remove(entity);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            using var context = new Context();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
