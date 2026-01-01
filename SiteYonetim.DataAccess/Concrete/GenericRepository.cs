using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.DataAccess.Concrete.Context;

namespace SiteYonetim.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new SiteYonetimContext();
            context.Remove(t);
            context.SaveChanges();
        }
        public void Insert(T t)
        {
            using var context = new SiteYonetimContext();
            context.Add(t);
            context.SaveChanges();
        }
        public List<T> GetListAll()
        {
            using var context = new SiteYonetimContext();
            return context.Set<T>().ToList();
        }
        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var context = new SiteYonetimContext();
            if (filter == null)
            {
                return context.Set<T>().ToList();
            }
            return context.Set<T>().Where(filter).ToList();
        }
        public void Update(T t)
        {
            using var context = new SiteYonetimContext();
            context.Update(t);
            context.SaveChanges();
        }
        public T GetByID(int id)
        {
            using var context = new SiteYonetimContext();
            return context.Set<T>().Find(id);
        }
    }
}