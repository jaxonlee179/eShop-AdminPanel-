using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.Admin.Models;

namespace eShop.Admin.Controllers
{
    //DI productImage , Unit, Category, ProductsinCategories
    public class ProductController : Controller
    {
        private readonly IProductsApplicationService _productsApplicationService;
        private readonly IProductsInCategoryApplicationService _productsInCategoryApplicationService;
        private readonly IPhotoApplicationService _photoApplicationService;
        private readonly IUnitServiceApplication _unitApplicationService;
        private readonly ICategoriesApplicationService _categoriesApplicationService;
        public ProductController(IProductsApplicationService productsServiceApplication,
                                 IProductsInCategoryApplicationService productsInCategoryApplicationService,
                                 IPhotoApplicationService photoApplicationService,
                                 IUnitServiceApplication unitServiceApplication,
                                 ICategoriesApplicationService categoriesApplicationService)
        {
            _productsApplicationService = productsServiceApplication;
            _categoriesApplicationService = categoriesApplicationService;
            _productsInCategoryApplicationService = productsInCategoryApplicationService;
            _unitApplicationService = unitServiceApplication;
            _photoApplicationService = photoApplicationService;
        }

        [HttpGet]
        public IActionResult ListProducts()
        {
            List<ProductsModel> model = new List<ProductsModel>();
          
            return View();
        }
    }
}
