using eShop.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface ICategoriesServiceDomain
    {
        IEnumerable<CategoryEntity> GetCategories();

        void AddCategory(CategoryEntity model);

        CategoryEntity GetCategoryById(string id);

        void UpdateCategory(CategoryEntity model);

        void DeleteCategory(string id);
    }
}
