using Entities.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductService : IEntityService<Product>
    {
        Product GetById(long Id);

        List<Product> GetProducts();
    }

}
