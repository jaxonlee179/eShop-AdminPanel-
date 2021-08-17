using eShop.DatabaseRepository.DbModels;
using eShop.DatabaseRepository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DatabaseRepository.DbRepos
{
    public class CategoryRepository : ICaterogyRepository
    {
        private AppDbContext _context;

        public void AddCategory(Categories category)
        {
            using (_context = new AppDbContext())
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }
        public void UpdateCategory(Categories category)
        {
            using (_context = new AppDbContext())
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
        }
        public void DeleteCategory(string id)
        {
            using (_context = new AppDbContext())
            {
                var category = (from c in _context.Categories
                                where c.Id == Guid.Parse(id)
                                select c).FirstOrDefault();

                if (category is not null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                }
            }
        }
        public IEnumerable<Categories> GetCategories()
        {

            using (_context = new AppDbContext())
            {
                var categories = (from c in _context.Categories
                                  select c).ToList();

                return categories;
            }
        }

        public Categories GetCategoryById(string id)
        {
            using (_context = new AppDbContext())
            {
                var category = (from c in _context.Categories
                                where c.Id == Guid.Parse(id)
                                select c).FirstOrDefault();

                return category;
            }
        }
    }
}
