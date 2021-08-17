using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface ICategoriesApplicationService
    {
        IEnumerable<CategoriesDTO> GetCategories();
        CategoriesDTO GetCategoryById(string id);

        void AddCategory(CategoriesDTO model);

        void UpdateCategory(CategoriesDTO model);

        void DeleteCategory(string id);
    }
}
