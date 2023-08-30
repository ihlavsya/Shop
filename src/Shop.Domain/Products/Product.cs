using Shop.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Shop.Products
{
	public class Product : AuditedAggregateRoot<Guid>, IHasEntityVersion
	{
		public ProductCategories ProductCategory { get; set; }

		public int EntityVersion { get; private set; } = 0;

		protected Product()
		{

		}

		public Product(Guid id)
		 : base(id)
		{

		}
		public Product(Guid id, ProductCategories productCategory) : base(id)
		{
			ProductCategory = productCategory;
			EntityVersion = 0;
		}

		public void UpdateVersion()
		{
			EntityVersion++;
		}
	}
}
