using Entities.Concrete;
using System.Linq;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEntityService<T> : IService where T : BaseEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
    }

}
