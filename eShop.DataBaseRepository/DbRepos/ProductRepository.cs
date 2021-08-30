using eShop.DatabaseRepository.DbModels;
using eShop.DatabaseRepository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eShop.DataTransferObject;
using System.Transactions;
using eShop.Utility;
using eShop.DomainModel.Entities;

namespace eShop.DatabaseRepository.DbRepos
{
    public class ProductRepository : IProductsRepository
    {
        private AppDbContext _context;

        public void AddProduct(ProductEntity model)
        {
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (_context = new AppDbContext())
                    {
                        Products product = new()
                        {
                            Id = Guid.NewGuid(),
                            Description = model.Description,
                            Name = model.Name,
                            Quantity = model.Quantity,
                            PhotoPath = model.PhotoPath,
                            DateCreate = DateTime.Now,
                            UnitId = (from u in _context.Units where u.Name == model.Unit select u.Id).First(),
                            Price = model.Price
                        };

                        _context.Products.Add(product);

                        ProductsInCategories productsInCategories = new ProductsInCategories()
                        {
                            ProductId = product.Id,
                            CategoryId = (from c in _context.Categories where c.Name == model.Category select c.Id).First()
                        };

                        _context.ProductsInCategories.Add(productsInCategories);

                        _context.SaveChanges();
                    }
                    transaction.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(ex.Message);
            }
        }
        public void UpdateProduct(ProductEntity model)
        {
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (_context = new AppDbContext())
                    {
                        Products product = new()
                        {
                            Id = Guid.Parse(model.Id),
                            Description = model.Description,
                            Name = model.Name,
                            Quantity = model.Quantity,
                            PhotoPath = model.PhotoPath,
                            DateCreate = (from p in _context.Products where p.Id == Guid.Parse(model.Id) select p.DateCreate).FirstOrDefault(),
                            DateChanged = DateTime.Now,
                            UnitId = (from u in _context.Units where u.Name == model.Unit select u.Id).First(),
                            Price = model.Price
                        };

                        _context.Products.Update(product);

                        ProductsInCategories productsInCategories = new ProductsInCategories()
                        {
                            ProductId = product.Id,
                            CategoryId = (from c in _context.Categories where c.Name == model.Category select c.Id).First()
                        };

                        _context.ProductsInCategories.Update(productsInCategories);

                        _context.SaveChanges();
                    }
                    transaction.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(ex.Message);
            }
        }

        public void DeleteProduct(string id)
        {
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (_context = new AppDbContext())
                    {
                        var query = (from pc in _context.ProductsInCategories where pc.ProductId == Guid.Parse(id) select pc).FirstOrDefault();

                        _context.Remove(query);
                        _context.SaveChanges();

                        var productQuery = (from p in _context.Products where p.Id == Guid.Parse(id) select p).FirstOrDefault();
                        productQuery.DateDeleted = DateTime.Now;
                        _context.SaveChanges();
                    }
                    transaction.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<ProductsDTO> GetAllProducts()
        {
            using (_context = new AppDbContext())
            {
                var query = (from p in _context.Products
                             where p.DateDeleted == null
                             join unit in _context.Units on p.UnitId equals unit.Id
                             join prodInCat in _context.ProductsInCategories on p.Id equals prodInCat.ProductId
                             join category in _context.Categories on prodInCat.CategoryId equals category.Id
                             select new ProductsDTO
                             {
                                 Id = p.Id.ToString(),
                                 PhotoPath = p.PhotoPath,
                                 Name = p.Name,
                                 Category = category.Name,
                                 Description = p.Description,
                                 Price = p.Price,
                                 Unit = unit.Name,
                                 Quantity = p.Quantity
                             }).ToList();

                return query;
            }
        }

        public ProductsDTO GetProductById(string id)
        {
            using (_context = new AppDbContext())
            {
                var query = (from p in _context.Products
                             where p.DateDeleted == null && p.Id.ToString() == id
                             select new ProductsDTO
                             {
                                 Id = p.Id.ToString(),
                                 Name = p.Name,
                                 Description = p.Description,
                                 Price = p.Price,
                                 Quantity = p.Quantity,
                                 Unit = (from u in _context.Units where u.Id == p.UnitId select u.Name).FirstOrDefault(),
                                 PhotoPath = p.PhotoPath
                             }).FirstOrDefault();

                return query;
            }
        }

        public T SelectAllCategoriesAndUnits<T>(T model) where T : class, new()
        {
            CategoriesAndUnitsDTO categoriesAndUnitsDTO = new CategoriesAndUnitsDTO();

            using (_context = new AppDbContext())
            {
                var unitsQuery = (from u in _context.Units
                                  select u.Name).ToList();

                var categoriesQuery = (from c in _context.Categories
                                       select c.Name).ToList();

                categoriesAndUnitsDTO.Units = unitsQuery;
                categoriesAndUnitsDTO.Categories = categoriesQuery;


                var mapper = ModelMapHandler.BuildModelMapping(categoriesAndUnitsDTO, model);

                return mapper;
            }
        }


    }
}
