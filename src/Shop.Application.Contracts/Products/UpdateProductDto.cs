using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Products
{
	public class UpdateProductDto
	{
		[Required]
		public ProductCategories ProductCategory { get; set; }
	}
}
