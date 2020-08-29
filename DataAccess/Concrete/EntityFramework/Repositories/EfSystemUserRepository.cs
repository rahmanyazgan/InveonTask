using DataAccess.Interfaces;
using Entities.Concrete;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfSystemUserRepository : EfGenericRepository<SystemUser>, ISystemUserRepository
    {
        public EfSystemUserRepository(DbContext context) : base(context)
        {

        }

        public SystemUser GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
