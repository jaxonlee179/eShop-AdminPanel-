using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IOrdersServiceDomain
    {
        IEnumerable<OrdersDTO> GetAllOrders();

        IEnumerable<OrderDetailsDTO> GetOrderDetailsByid(string id);
    }
}
