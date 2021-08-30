using eShop.DatabaseRepository.RepositoryInterface;
using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DatabaseRepository.DbRepos
{
    public class OrdersRepository : IOrdersRepository
    {
        private AppDbContext _context;
        public OrdersRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<OrdersDTO> GetAllOrders()
        {
            using (_context = new AppDbContext())
            {
                var query = (from u in _context.Users
                             join o in _context.Orders on u.Id equals o.ApplicationUsers.Id
                             join orderStatus in _context.OrderStatus on o.OrderStatus.Id equals orderStatus.Id
                             select new OrdersDTO
                             {
                                 Id = o.Id.ToString(),
                                 Email = u.Email,
                                 Address = u.Address,
                                 OrderStatus = orderStatus.Name,
                                 TotalPrice = o.TotalPrice,
                                 DateCreated = o.DateCreated,
                                 DateChanged = o.DateChanged
                             }).ToList();

                return query;
            }
        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetailsByid(string id)
        {
            using (_context = new AppDbContext())
            {
                var query = (from od in _context.OrderDetails
                             where od.OrderId == Guid.Parse(id)
                             join p in _context.Products on od.ProductId equals p.Id
                             select new OrderDetailsDTO
                             {
                                 OrderId = od.OrderId.ToString(),
                                 ProductId = p.Id.ToString(),
                                 Price = od.Price,
                                 Quantity = od.Quantity,
                                 ProductName = p.Name
                             }).ToList();

                return query;
            }
        }
    }
}
