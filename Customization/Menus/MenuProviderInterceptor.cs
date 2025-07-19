using EPiServer.Shell.Navigation;

namespace alloy_example.Customization.Menus;

public class MenuProviderInterceptor : IMenuProvider
{
    private readonly IMenuProvider _menu;

    public MenuProviderInterceptor(IMenuProvider menu)
    {
        _menu = menu;
    }

    public IEnumerable<MenuItem> GetMenuItems()
    {
        var menuItems = _menu.GetMenuItems().ToList();
        return menuItems;
    }
}
