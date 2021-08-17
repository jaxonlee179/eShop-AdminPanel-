using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }
    }
}
