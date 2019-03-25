using Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IDisposable where T : class
    {
        protected readonly GerenciadorContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository()
        {
            Db = new GerenciadorContext();
            Db.Configuration.ProxyCreationEnabled = false;
            DbSet = Db.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Delete(T entity)
        {
            //DbSet.Remove(entity);

            bool oldValidateOnSaveEnabled = Db.Configuration.ValidateOnSaveEnabled;

            try
            {
                Db.Configuration.ValidateOnSaveEnabled = false;

                DbSet.Attach(entity);
                Db.Entry(entity).State = EntityState.Deleted;
                Db.SaveChanges();
            }
            finally
            {
                Db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
            }
        }

        public IEnumerable<T> GetBy(Func<T, bool> predicate)
        {
            using (var Db2 = new GerenciadorContext())
            {
                var DbSet2 = Db2.Set<T>();
                return DbSet2.Where(predicate)?.ToList();
            }
        }

        public T GetBy(int id)
        {
            return DbSet.Find(id);
        }

        public List<T> GetList()
        {
            using (var Db2 = new GerenciadorContext())
            {
                var DbSet2 = Db2.Set<T>();
                return DbSet2.ToList();
            }
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
        }

        public void Update2(T entity)
        {
            using (var Db2 = new GerenciadorContext())
            {
                Db.Entry(entity).State = EntityState.Modified;
                Db.SaveChanges();
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
