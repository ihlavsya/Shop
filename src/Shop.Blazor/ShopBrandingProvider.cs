using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Shop.Blazor;

[Dependency(ReplaceServices = true)]
public class ShopBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Shop";
}
