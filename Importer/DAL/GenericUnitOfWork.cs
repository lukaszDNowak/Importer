﻿using Importer.DAL;
using Importer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.DAL
{
    public class GenericUnitOfWork : IDisposable
    {
        private ImporterContext db = null;
        public GenericUnitOfWork(ImporterContext db)
        {
            this.db = db;
        }
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IRepository<T>;
            IRepository<T> repo = new Repository<T>(db);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
