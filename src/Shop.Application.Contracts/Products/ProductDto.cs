using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Shop.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public ProductCategories ProductCategory { get; private set; }
        public string? PhotoPath { get; private set; }
    }
}
