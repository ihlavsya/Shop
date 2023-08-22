using System;
using System.Threading.Tasks;
using System.Xml.Linq;
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
	//[Dependency(ReplaceServices = true)]
	//[ExposeServices(typeof(Controller))]
	public class ProductController : Controller
	{
		private readonly IProductAppService _productAppService;
		public ProductController(IProductAppService productAppService)
		{
			_productAppService = productAppService;
		}
		[HttpPut("api/app/products/{id}")]
		public Task<ProductDto> UpdateEntityAsync(Guid id, CreateUpdateProductDto createUpdateProductDto)
		{
			var a = 3;
			return new Task<ProductDto>(() => new ProductDto());
		}
	}
}
