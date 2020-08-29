using DataAccess.Interfaces;
using Entities.Concrete;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.Concrete
{
    public class EfGenericRepository<T> :
        IGenericRepository<T> where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public EfGenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        //public T Get(params object[] keys)
        //{
        //    return _dbset.Find(keys);
        //}

        public virtual T Get(Func<T, bool> predicate = null)
        {
            return _dbset.First(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
