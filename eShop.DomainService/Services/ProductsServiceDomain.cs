using eShop.DatabaseRepository.RepositoryInterface;
using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Utility;
using eShop.DomainModel.Entities;

namespace eShop.DomainService.Services
{
    public class ProductsServiceDomain : IProductsServiceDomain
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsServiceDomain(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void AddProduct(ProductEntity model)
        {
            _productsRepository.AddProduct(model);
        }

        public void UpdateProduct(ProductEntity model)
        {
            _productsRepository.UpdateProduct(model);
        }

        public IEnumerable<ProductsDTO> GetAllProducts()
        {
           return _productsRepository.GetAllProducts();
        }

        public ProductsDTO GetProductById(string id)
        {
            return _productsRepository.GetProductById(id);
        }

        public T SelectAllCategoriesAndUnits<T>(T model) where T : class, new()
        {

            return _productsRepository.SelectAllCategoriesAndUnits(model);
        }

        public void DeleteProduct(string id)
        {
            _productsRepository.DeleteProduct(id);
        }
    }
}
