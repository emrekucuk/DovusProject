using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DovusProject.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        T Get(Expression<Func<T, bool>> expression);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);

      
        int SaveChanges();

        Task<int> SaveChangesAsync();

    }
}