using BusinessLogicLayer.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;
using System.Collections.Generic;

namespace BusinessLogicLayer.Concrete
{
    public class ProductService : EntityService<Product>, IProductService
    {
        IUnitOfWork _unitOfWork;
        IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
            : base(unitOfWork, productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public Product GetById(int Id)
        {
            return _productRepository.GetById(Id);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
