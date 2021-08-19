using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Utility;
using eShop.DomainModel.Entities;

namespace eShop.ApplicationService.Services
{
    public class ProductsApplicationService : IProductsApplicationService
    {
        private readonly IProductsServiceDomain _productsServiceDomain;

        public ProductsApplicationService(IProductsServiceDomain productsServiceDomain)
        {
            _productsServiceDomain = productsServiceDomain;
        }

        public void AddProduct(ProductsDTO model)
        {
            var productEntity = ModelMapHandler.BuildModelMapping(model, new ProductEntity());
            _productsServiceDomain.AddProduct(productEntity);
        }
        public void UpdateProduct(ProductsDTO model)
        {
            var productEntity = ModelMapHandler.BuildModelMapping(model, new ProductEntity());
            _productsServiceDomain.UpdateProduct(productEntity);
        }

        public void DeleteProduct(string id)
        {
            _productsServiceDomain.DeleteProduct(id);
        }
        public IEnumerable<ProductsDTO> GetAllProducts()
        {
            return _productsServiceDomain.GetAllProducts();
        }

        public ProductsDTO GetProductById(string id)
        {
            var productEntity = _productsServiceDomain.GetProductById(id);
            var mapper = ModelMapHandler.BuildModelMapping(productEntity, new ProductsDTO());
            return mapper;
        }

        public T SelectAllCategoriesAndUnits<T>(T model) where T : class, new()
        {
            return _productsServiceDomain.SelectAllCategoriesAndUnits(model);
        }


    }
}
