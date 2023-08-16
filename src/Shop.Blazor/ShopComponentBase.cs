using Shop.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Shop.Blazor;

public abstract class ShopComponentBase : AbpComponentBase
{
    protected ShopComponentBase()
    {
        LocalizationResource = typeof(ShopResource);
    }
}
