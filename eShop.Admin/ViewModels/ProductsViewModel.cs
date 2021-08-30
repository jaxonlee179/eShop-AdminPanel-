using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {
            Categories = new List<string>();
            Units = new List<string>();
        }
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public IEnumerable<string> Categories { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public IEnumerable<string> Units { get; set; }

        [Required]
        [Display(Name = "Unit")]
        public string Unit { get; set; }

        [Required]
        public double Quantity { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }
    }
}
