using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class ProductsDTO
    {
        public string Name { get; set; }

        public IEnumerable<string> Category { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Unit { get; set; }

        public double Quantity { get; set; }
    }
}
