using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.DataTransferObject;

namespace eShop.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoriesApplicationService _categoriesServiceApplication;
        private const string _emptyString = "";
        public CategoryController(ICategoriesApplicationService categoriesServiceApplication)
        {
            _categoriesServiceApplication = categoriesServiceApplication;
        }

        [HttpGet]
        public IActionResult ListCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            var categoriesDTO = _categoriesServiceApplication.GetCategories();

            foreach (var categoryDTO in categoriesDTO)
            {
                var model = ModelMapHandler.BuildModelMapping(categoryDTO, new CategoryModel());
                categories.Add(model);
            }

            return View(categories);
        }

        [HttpGet]
        public IActionResult AddOrEdit(string id = _emptyString)
        {
            //CategoryModel category = new CategoryModel();

            if (string.IsNullOrEmpty(id))
            {
                return PartialView();
            }
            //edit
            var categoriesDTO = _categoriesServiceApplication.GetCategoryById(id);
            var model = ModelMapHandler.BuildModelMapping(categoriesDTO, new CategoryModel());

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddOrEdit(string id, CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var mapper = ModelMapHandler.BuildModelMapping(model, new CategoriesDTO());

                if (string.IsNullOrEmpty(id))
                {
                    _categoriesServiceApplication.AddCategory(mapper);
                }
                else
                {
                    _categoriesServiceApplication.UpdateCategory(mapper);
                }
            }
            else
            {
                return View(model);
            }
            return RedirectToAction("ListCategories");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            _categoriesServiceApplication.DeleteCategory(id);

            return RedirectToAction("ListCategories");
        }
    }
}
