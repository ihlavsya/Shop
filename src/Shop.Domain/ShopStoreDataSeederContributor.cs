using Shop.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Shop
{
    public class ShopStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IGuidGenerator _guidGenerator;

        public ShopStoreDataSeederContributor(IRepository<Product, Guid> productRepository, IGuidGenerator guidGenerator)
        {
            _productRepository = productRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _productRepository.GetCountAsync() <= 0)
            {
                await _productRepository.InsertAsync(
                    new Product(_guidGenerator.Create(), ProductCategories.WomensFashion),
                    autoSave: true
                );
                await _productRepository.InsertAsync(
                    new Product(_guidGenerator.Create(), ProductCategories.MensFashion),
                    autoSave: true
                );
            }
        }

    }
}

