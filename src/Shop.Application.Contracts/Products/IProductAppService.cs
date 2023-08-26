using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Shop.Products
{
    public interface IProductAppService :ICrudAppService<ProductDto, //Used to show products
        Guid, //Primary key of the product entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateProductDto, 
        UpdateProductDto>
    {
        //Task<CreateUpdateProductDto> UpdateAsync(CreateUpdateProductDto input);
	}
}
