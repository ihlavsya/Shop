using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        public ProductCategories ProductCategory { get; private set; }
        [Required]
        [StringLength(1000)]
        public string? PhotoPath { get; private set; }
    }
}
