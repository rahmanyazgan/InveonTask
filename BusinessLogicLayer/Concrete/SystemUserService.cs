using BusinessLogicLayer.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace BusinessLogicLayer.Concrete
{
    public class SystemUserService : EntityService<SystemUser>, ISystemUserService
    {
        IUnitOfWork _unitOfWork;
        ISystemUserRepository _systemUserRepository;

        public SystemUserService(IUnitOfWork unitOfWork, ISystemUserRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _systemUserRepository = personRepository;
        }

        public SystemUser GetById(int Id)
        {
            return _systemUserRepository.GetById(Id);
        }
    }
}
