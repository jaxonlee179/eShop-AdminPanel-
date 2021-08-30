using eShop.ApplicationService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Utility;
using eShop.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrdersApplicationService _ordersApplicationService;
        public OrderController(IOrdersApplicationService ordersApplicationService)
        {
            _ordersApplicationService = ordersApplicationService;
        }

        [HttpGet]
        public IActionResult ListOrders()
        {
            var orderDTO = _ordersApplicationService.GetAllOrders();

            List<OrderModel> orderList = new List<OrderModel>();

            foreach (var order in orderDTO)
            {
                var model = ModelMapHandler.BuildModelMapping(order, new OrderModel());
                orderList.Add(model);
            }

            return View(orderList);
        }

        [HttpGet]
        public IActionResult OrderDetails(string id)
        {
            var orderDetailsDTO = _ordersApplicationService.GetOrderDetailsById(id);

            List<OrderDetailsModel> orderDetailsList = new();

            foreach (var orderDetail in orderDetailsDTO)
            {
                var model = ModelMapHandler.BuildModelMapping(orderDetail, new OrderDetailsModel());
                orderDetailsList.Add(model);
            }
            return PartialView(orderDetailsList);
        }
    }
}
