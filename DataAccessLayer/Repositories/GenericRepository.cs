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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new Context())
            {
                context.SaveChanges();
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetList()
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
