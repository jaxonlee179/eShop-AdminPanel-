using eShop.DatabaseRepository.RepositoryInterface;
using eShop.DomainModel.Entities;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Utility;
using eShop.DatabaseRepository.DbModels;

namespace eShop.DomainService.Services
{
    public class CategoriesServiceDomain : ICategoriesServiceDomain
    {
        private readonly ICaterogyRepository _caterogyRepository;
        public CategoriesServiceDomain(ICaterogyRepository caterogyRepository)
        {
            _caterogyRepository = caterogyRepository;
        }

        public IEnumerable<CategoryEntity> GetCategories()
        {
            List<CategoryEntity> categoryEntities = new List<CategoryEntity>();

            foreach (var category in _caterogyRepository.GetCategories())
            {
                var categoryEntity = ModelMapHandler.BuildModelMapping(category, new CategoryEntity());

                categoryEntities.Add(categoryEntity);
            }
            return categoryEntities;
        }

        public CategoryEntity GetCategoryById(string id)
        {
            var model = _caterogyRepository.GetCategoryById(id);
            var categoryEntity = ModelMapHandler.BuildModelMapping(model, new CategoryEntity());

            return categoryEntity;
        }
        public void AddCategory(CategoryEntity model)
        {
            if (model.IsNameEmpty() || model.RequiredLength(3))
            {
                throw new Exception("Name was Empty or too short");
            }

            Categories categories = new Categories()
            {
                Id = Guid.NewGuid(),
                Name = model.Name
            };

            _caterogyRepository.AddCategory(categories);
        }

        public void UpdateCategory(CategoryEntity model)
        {
            if (model.IsNameEmpty() || model.RequiredLength(3))
            {
                throw new Exception("Name was Empty or too short");
            }

            var mapper = ModelMapHandler.BuildModelMapping(model, new Categories());
            _caterogyRepository.UpdateCategory(mapper);
        }

        public void DeleteCategory(string id)
        {
            _caterogyRepository.DeleteCategory(id);
        }
    }
}
