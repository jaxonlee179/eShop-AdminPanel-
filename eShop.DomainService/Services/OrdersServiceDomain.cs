using eShop.DatabaseRepository.RepositoryInterface;
using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class OrdersServiceDomain : IOrdersServiceDomain
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersServiceDomain(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IEnumerable<OrdersDTO> GetAllOrders()
        {
            return _ordersRepository.GetAllOrders();
        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetailsByid(string id)
        {
            return _ordersRepository.GetOrderDetailsByid(id);
        }
    }
}
