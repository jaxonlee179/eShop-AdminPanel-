using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.DataTransferObject;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IOrdersApplicationService
    {
        IEnumerable<OrdersDTO> GetAllOrders();

        IEnumerable<OrderDetailsDTO> GetOrderDetailsById(string id);
    }
}
