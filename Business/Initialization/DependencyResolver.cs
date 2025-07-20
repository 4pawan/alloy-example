using alloy_example.Customization.Caching;
using alloy_example.Customization.Menus;
using EPiServer.Cms.Shell.UI.Dashboard.Internal;
using EPiServer.Cms.Shell.UI.Reports.Internal;
using EPiServer.Shell.Navigation;
using Microsoft.AspNetCore.OutputCaching;

namespace alloy_example.Business.Initialization;

public class DependencyResolver
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IOutputCachePolicy, MyCustomCache>();
        services.Intercept<IMenuProvider>(interceptorFactory);

    }

    private static IMenuProvider interceptorFactory(IServiceProvider provider1, IMenuProvider provider2)
    {
        var types = new[] { typeof(ReportsMenuProvider), typeof(DashboardMenuProvider) };
        return types.Any(t => t.Equals(provider2.GetType())) ? new MenuProviderInterceptor(provider2) : provider2;
    }
}