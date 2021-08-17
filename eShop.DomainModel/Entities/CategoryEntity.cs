using eShop.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainModel.Entities
{
    public class CategoryEntity : BaseValueObjects
    {
        public string Id { get; set; }

        public string Name { get; set; }


        public bool IsNameEmpty()
        {
            return string.IsNullOrEmpty(Name);
        }

        public bool RequiredLength(byte requiredLength)
        {
            return Name.Length < requiredLength;
        }
    }
}
