using System;
using System.Linq.Expressions;
using System.Linq;
using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }

}
