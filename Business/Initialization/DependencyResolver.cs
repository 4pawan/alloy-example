using alloy_example.Customization.Caching;
using alloy_example.Customization.Menus;
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
        IMenuProvider menuProvider = new MenuProviderInterceptor(provider2);
        return menuProvider;
    }
}