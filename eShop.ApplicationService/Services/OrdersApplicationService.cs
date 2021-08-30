using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class OrdersApplicationService : IOrdersApplicationService
    {
        private readonly IOrdersServiceDomain _ordersServiceDomain;
        public OrdersApplicationService(IOrdersServiceDomain ordersServiceDomain)
        {
            _ordersServiceDomain = ordersServiceDomain;
        }
        public IEnumerable<OrdersDTO> GetAllOrders()
        {
            return _ordersServiceDomain.GetAllOrders();
        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetailsById(string id)
        {
            return _ordersServiceDomain.GetOrderDetailsByid(id);
        }
    }
}
