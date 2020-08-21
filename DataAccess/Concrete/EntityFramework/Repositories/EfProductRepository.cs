using DataAccess.Interfaces;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        public EfProductRepository(DbContext context) : base(context)
        {

        }

        public Product GetById(long id)
        {
            return FindBy(p => p.Id == id).FirstOrDefault();
        }

        public List<Product> GetAllProducts()
        {
            return FindBy(p => p.IsDeleted == false).ToList();
        }
    }

}
