using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DatabaseRepository.RepositoryInterface
{
    public interface ICategoriesAndUnitSelector
    {
        T SelectAllCategoriesAndUnits<T>(T model) where T : class, new();
    }
}
