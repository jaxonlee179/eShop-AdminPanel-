using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
   public class OrdersDTO
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string OrderStatus { get; set; }

        public double TotalPrice { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateChanged { get; set; }
    }
}
