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
using Volo.Abp;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Web.Http;

namespace Shop.Products
{
	[RemoteService(IsEnabled = false)]
	[ExposeServices(typeof(IProductAppService), typeof(ProductAppService), typeof(CrudAppService<
		Product, //The Product entity
		ProductDto, //Used to show Products
		Guid, //Primary key of the Product entity
		PagedAndSortedResultRequestDto,//Used for paging/sorting
		CreateProductDto,
		UpdateProductDto>))]
	public class ProductAppService : CrudAppService<
		Product, //The Product entity
		ProductDto, //Used to show Products
		Guid, //Primary key of the Product entity
		PagedAndSortedResultRequestDto, //Used for paging/sorting
		CreateProductDto,
		UpdateProductDto>, //Used to create/update a Product
	IProductAppService //implement the IProductAppService

	{
		private readonly IRepository<Product, Guid> _repository;
		public ProductAppService(IRepository<Product, Guid> repository)
		: base(repository)
		{
			_repository = repository;
		}

		//public async override Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
		//      {
		//          var product = await _repository.FirstOrDefaultAsync(x => x.Id == id);

		//	product.ProductCategory = input.ProductCategory;
		//	product.UpdateVersion();
		//	await _repository.UpdateAsync(product);

		//	await _fileAppService.SaveManyBlobsAsync(input.SaveBlobInputDtos);
		//	await _fileAppService.DeleteManyBlobsAsync(input.GetBlobRequestDtosToBeDeleted);

		//	var productDto = ObjectMapper.Map<Product, ProductDto>(product);
		//	productDto.GetBlobRequestDtos = ObjectMapper.Map<IEnumerable<SaveBlobInputDto>, IEnumerable<GetBlobRequestDto>>(input.SaveBlobInputDtos);
		//	return productDto;
		//      }
		public async override Task<ProductDto> GetAsync(Guid id)
		{
			var product = await _repository.GetAsync(id);
			var productDto = ObjectMapper.Map<Product, ProductDto>(product);
			return productDto;
		}
		public async override Task<ProductDto> CreateAsync(CreateProductDto input)
		{
			var product = ObjectMapper.Map<CreateProductDto, Product>(input);

			product = await _repository.InsertAsync(product);

			// await SaveFiles(input.Files);

			var productDto = ObjectMapper.Map<Product, ProductDto>(product);
			// productDto.GetBlobRequestDtos = ObjectMapper.Map<IEnumerable<string>, IEnumerable<GetBlobRequestDto>>(input.Files.Select(f => f.FileName));
			return productDto;
		}

		//private async Task SaveFiles(IEnumerable<IFormFile> files)
		//{
		//	using (var memoryStream = new MemoryStream())
		//	{
		//		foreach (var file in files)
		//		{
		//			await file.CopyToAsync(memoryStream);
		//			await _fileAppService.SaveBlobAsync(
		//				new SaveBlobInputDto
		//				{
		//					Name = file.FileName,
		//					Content = memoryStream.ToArray()
		//				});
		//			memoryStream.Position = 0;
		//		}
		//	}
		//}
	}
}
