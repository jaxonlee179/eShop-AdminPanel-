using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.Admin.Models;
using eShop.Utility;
using eShop.Admin.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using eShop.DataTransferObject;

namespace eShop.Admin.Controllers
{
    //DI productImage , Unit, Category, ProductsinCategories
    public class ProductController : Controller
    {
        private readonly IProductsApplicationService _productsApplicationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private const string _stringEmpty = "";
        public ProductController(IProductsApplicationService productsApplicationService, IWebHostEnvironment hostEnvironment)
        {
            _productsApplicationService = productsApplicationService;
            _hostingEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult ListProducts()
        {
            List<ProductsModel> model = new List<ProductsModel>();
            foreach (var product in _productsApplicationService.GetAllProducts())
            {
                var productModel = ModelMapHandler.BuildModelMapping(product, new ProductsModel());
                model.Add(productModel);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddOrEdit(string id = _stringEmpty)
        {

            ProductsViewModel model = new ProductsViewModel();
            _productsApplicationService.SelectAllCategoriesAndUnits(model);
            //add
            if (string.IsNullOrEmpty(id))
            {
                return PartialView(model);
            }

            //edit
            var productDTO = _productsApplicationService.GetProductById(id);
            model = ModelMapHandler.BuildModelMapping(productDTO, model);

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddOrEdit(string id, ProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                ProductsModel product = new ProductsModel()
                {
                    Name = model.Name,
                    Category = model.Category,
                    Description = model.Description,
                    Quantity = model.Quantity,
                    Unit = model.Unit,
                    Price = model.Price,
                };

                var mapper = ModelMapHandler.BuildModelMapping(model, new ProductsDTO());
                mapper.PhotoPath = uniqueFileName;

                if (string.IsNullOrEmpty(id))
                {
                    _productsApplicationService.AddProduct(mapper);
                }
                else
                {
                    if (model.PhotoPath is not null)
                    {
                        DeleteUploadedFile(model.PhotoPath);
                    }
                    _productsApplicationService.UpdateProduct(mapper);
                }
            }

            else
            {
                _productsApplicationService.SelectAllCategoriesAndUnits(model);
                return View(model);
            }

            return RedirectToAction("ListProducts");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var productDTO = _productsApplicationService.GetProductById(id);
            DeleteUploadedFile(productDTO.PhotoPath);

            _productsApplicationService.DeleteProduct(id);

            return RedirectToAction("ListProducts");
        }
        private string ProcessUploadedFile(ProductsViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo is not null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(stream);
                }
            }
            return uniqueFileName;
        }

        private void DeleteUploadedFile(string filename)
        {
            string directoryPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            string filepath = Path.Combine(directoryPath, filename);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
        }
    }
}
