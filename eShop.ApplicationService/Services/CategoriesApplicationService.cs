using eShop.ApplicationService.ServiceInterfaces;
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

namespace eShop.ApplicationService.Services
{
    public class CategoriesApplicationService : ICategoriesApplicationService
    {
        private readonly ICategoriesServiceDomain _categoriesServiceDomain;

        public CategoriesApplicationService(ICategoriesServiceDomain categoriesServiceDomain)
        {
            _categoriesServiceDomain = categoriesServiceDomain;
        }

        public IEnumerable<CategoriesDTO> GetCategories()
        {
            List<CategoriesDTO> categoriesDTO = new List<CategoriesDTO>();

            foreach (var category in _categoriesServiceDomain.GetCategories())
            {
                var categoryDTO = ModelMapHandler.BuildModelMapping(category, new CategoriesDTO()) ;

                categoriesDTO.Add(categoryDTO);
            }

            return categoriesDTO;
        }

        public CategoriesDTO GetCategoryById(string id)
        {
            var categoryEntity = _categoriesServiceDomain.GetCategoryById(id);
            var categoriesDTO = ModelMapHandler.BuildModelMapping(categoryEntity, new CategoriesDTO());

            return categoriesDTO;
        }
        public void AddCategory(CategoriesDTO model)
        {
            var categoryEntity = ModelMapHandler.BuildModelMapping(model, new CategoryEntity());

            _categoriesServiceDomain.AddCategory(categoryEntity);
        }

        public void UpdateCategory(CategoriesDTO model)
        {
            var categoryEntity = ModelMapHandler.BuildModelMapping(model, new CategoryEntity());

            _categoriesServiceDomain.UpdateCategory(categoryEntity);
        }

        public void DeleteCategory(string id)
        {
            _categoriesServiceDomain.DeleteCategory(id);
        }
    }
}
