using DataAccess.Interfaces;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetById(long id);

        List<Product> GetAllProducts();
    }
}
