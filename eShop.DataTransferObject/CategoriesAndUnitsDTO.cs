using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class CategoriesAndUnitsDTO
    {
        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Units { get; set; }
    }
}
