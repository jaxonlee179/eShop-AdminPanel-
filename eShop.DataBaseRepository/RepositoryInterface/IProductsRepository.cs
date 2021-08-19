using eShop.DatabaseRepository.DbModels;
using eShop.DataTransferObject;
using eShop.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DatabaseRepository.RepositoryInterface
{
    public interface IProductsRepository : ICategoriesAndUnitSelector
    {
        IEnumerable<ProductsDTO> GetAllProducts();

        ProductsDTO GetProductById(string id);

        void AddProduct(ProductEntity model);

        void UpdateProduct(ProductEntity model);

        void DeleteProduct(string id);
    }
}
