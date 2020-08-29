using Entities.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductService : IEntityService<Product>
    {
        Product GetById(int Id);

        List<Product> GetProducts();
    }

}
