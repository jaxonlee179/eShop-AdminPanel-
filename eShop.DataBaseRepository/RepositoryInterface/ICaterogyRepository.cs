using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.DatabaseRepository.DbModels;

namespace eShop.DatabaseRepository.RepositoryInterface
{
    public interface ICaterogyRepository
    {
        Categories GetCategoryById(string id);

        IEnumerable<Categories> GetCategories();

        void AddCategory(Categories category);

        void UpdateCategory(Categories category);

        void DeleteCategory(string id);
    }
}
