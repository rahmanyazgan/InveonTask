using Entities.Concrete;


namespace BusinessLogicLayer.Interfaces
{
    public interface ISystemUserService : IEntityService<SystemUser>
    {
        SystemUser GetById(long Id);
    }

}
