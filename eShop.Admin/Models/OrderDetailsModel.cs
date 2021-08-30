using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    public class OrderDetailsModel
    {
        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }
    }
}
