using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface ISystemUserRepository : IGenericRepository<SystemUser>
    {
        SystemUser GetById(int id);
    }
}
