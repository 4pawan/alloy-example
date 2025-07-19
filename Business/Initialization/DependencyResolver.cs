using alloy_example.Customization.Caching;
using Microsoft.AspNetCore.OutputCaching;

namespace alloy_example.Business.Initialization;

public class DependencyResolver
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IOutputCachePolicy, MyCustomCache>();
    }
}