using Blazorise;
using Shop.Products;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BlazoriseUI;

namespace Shop.Blazor.Pages
{
	public class ProductCrudPage : AbpCrudPageBase<IProductAppService, ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductDto>
	{
		protected override async Task<ProductDto> UpdateEntityAsync()
		{
			var productDto = await base.AppService.UpdateAsync(base.EditingEntityId, base.EditingEntity);
			return productDto;
		}

		protected string GetPhotoPath(string shortPhotoPath)
		{
			var res = $"C:\\Users\\User\\source\\repos\\Shop\\src\\Shop.Blazor\\wwwroot\\product-images\\{shortPhotoPath}";
			return res;
		}

		protected async Task OnFilesUploaded(FileChangedEventArgs e)
		{
			try
			{
				foreach (var file in e.Files)
				{
					NewEntity.PhotoPath = file.Name;
					// A stream is going to be the destination stream we're writing to.
					try
					{
						using (Stream s = File.Create(GetPhotoPath(file.Name)))
						{
							await file.WriteToStreamAsync(s);
						}
					}
					catch (Exception ex)
					{
						var a = 3;
					}

				}
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
			finally
			{
				this.StateHasChanged();
			}
		}
	}
}
