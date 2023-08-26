using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Http;

namespace Shop.Products
{
    public class CreateProductDto
    {
        [Required]
		[BindProperty]
		public ProductCategories ProductCategory { get; set; }
		[Required]
		[BindProperty]
		public IEnumerable<IFormFile> Files { get; set; }
    }
}
