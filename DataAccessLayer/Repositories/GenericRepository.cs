using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, new()
    {

        Context context = new Context();

        DbSet<TEntity> _object;

        public GenericRepository()
        {
            _object = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<TEntity> GetList()
        {
            return _object.ToList();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
