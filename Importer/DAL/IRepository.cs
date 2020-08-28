using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Importer.DAL
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IEnumerable<T> GetAll();

        void AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Delete(T entity);
        T GetDetail(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate = null);

    }
}