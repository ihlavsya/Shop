using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Products;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Controllers;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.DependencyInjection;

namespace Shop.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductAppService _productAppService;
		public ProductController(IProductAppService productAppService)
		{
			_productAppService = productAppService;
		}
		//[HttpPut("api/app/product/{id}")]
		//public async Task<ProductDto> UpdateEntityAsync(Guid id, UpdateProductDto updateProductDto)
		//{
		//	var productDto = await _productAppService.UpdateAsync(id, updateProductDto);
		//	return productDto;
		//}

		[HttpPost("api/app/product")]
		public async Task<ProductDto> CreateEntityAsync(CreateProductDto createProductDto)
		{
			var productDto = await _productAppService.CreateAsync(createProductDto);
			return productDto;
		}

		[HttpGet("api/app/product/{id}")]
		public async Task<ProductDto> GetEntityAsync(Guid id)
		{
			var productDto = await _productAppService.GetAsync(id);
			return productDto;
		}
	}
}
