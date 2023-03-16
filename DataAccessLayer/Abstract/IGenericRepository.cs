using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        List<TEntity> GetList();
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter);
    }
}
