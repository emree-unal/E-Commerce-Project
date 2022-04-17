using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Amazon.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter=null);
        List<T> GetAllEntities(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
