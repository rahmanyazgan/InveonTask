using System;
using System.Linq.Expressions;
using System.Linq;
using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Get(Func<T, bool> predicate = null);

        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
