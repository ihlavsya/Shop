using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Volo.Abp.ObjectMapping;

namespace Shop.Products
{
	[Dependency(ReplaceServices = true)]
	[ExposeServices(typeof(IProductAppService), typeof(ProductAppService), typeof(CrudAppService<
		Product, //The Product entity
		ProductDto, //Used to show Products
		Guid, //Primary key of the Product entity
		PagedAndSortedResultRequestDto, //Used for paging/sorting
		CreateUpdateProductDto>))]
	public class ProductAppService : CrudAppService<
        Product, //The Product entity
        ProductDto, //Used to show Products
        Guid, //Primary key of the Product entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductDto>, //Used to create/update a Product
    IProductAppService //implement the IProductAppService
        
	{
		private readonly IRepository<Product, Guid> _repository;
		public ProductAppService(IRepository<Product, Guid> repository)
        : base(repository)
        {
            _repository = repository;
        }

		public async override Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            product.Update(input.ProductCategory, input.PhotoPath);
			var productDto = ObjectMapper.Map<Product, ProductDto>(product);
			return productDto;
        }

	}
}
