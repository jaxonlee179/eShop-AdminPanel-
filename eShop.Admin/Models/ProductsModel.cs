using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    public class ProductsModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Unit { get; set; }

        public double Quantity { get; set; }

        public string PhotoPath { get; set; }
    }
}
