using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Importer.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ImporterContext db = null;
        DbSet<T> dbSet;
        public Repository(ImporterContext _db)
        {
            db = _db;
            dbSet = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public void Add(T entity)
        {
            dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void AddRangeAsync(IEnumerable<T> entities)
        {
            dbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public T GetDetail(Expression<Func<T, bool>> predicate)
        {
            return dbSet.First(predicate);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return dbSet.Where(predicate);
            return dbSet.AsEnumerable();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

    }
}
