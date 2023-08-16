using Shop.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Shop.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ShopEntityFrameworkCoreModule),
    typeof(ShopApplicationContractsModule)
    )]
public class ShopDbMigratorModule : AbpModule
{
}
