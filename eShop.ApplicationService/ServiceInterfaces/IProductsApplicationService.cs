using eShop.DatabaseRepository.RepositoryInterface;
using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IProductsApplicationService : ICategoriesAndUnitSelector
    {
        IEnumerable<ProductsDTO> GetAllProducts();

        ProductsDTO GetProductById(string id);

        void AddProduct(ProductsDTO model);

        void UpdateProduct(ProductsDTO model);

        void DeleteProduct(string id);
    }
}
