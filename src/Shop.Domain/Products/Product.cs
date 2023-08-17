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
        public ProductCategories ProductCategory { get; private set; }
        public string? PhotoPath { get; private set; }

        // where update it?
        public int EntityVersion { get; private set; } = 0;

        protected Product()
        {

        }

        public Product(Guid id)
         : base(id)
        {

        }
        public Product(Guid id, ProductCategories productCategory, string photoPath): base(id)
        {
            ProductCategory = productCategory;
            PhotoPath = photoPath;
            EntityVersion = 0;
        }
    }
}
