using EPiServer.ServiceLocation;

namespace alloy_example.Helpers;

/// <summary>
/// Provides extension methods for categorizable content
/// </summary>
/// <remarks>ICategorizable content includes for example pages and blocks.</remarks>
public static class CategorizableExtensions
{
    /// <summary>
    /// Returns the CSS classes (if any) associated with the theme(s) of the content, as decided by its categories
    /// </summary>
    /// <param name="content"></param>
    /// <returns>CSS classes associated with the content's theme(s), or an empty string array if no theme is applicable</returns>
    /// <remarks>Content's categorization may map to more than one theme. This method assumes there are website categories called "Meet", "Track", and "Plan"</remarks>
    public static string[] GetThemeCssClassNames(this ICategorizable content)
    {
        if (content.Category == null)
        {
            return [];
        }

        // Although with some overhead, a HashSet allows us to ensure we never add a CSS class more than once
        var cssClasses = new HashSet<string>();
        var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();

        foreach (var categoryName in content.Category.Select(category => categoryRepository.Get(category).Name.ToLowerInvariant()))
        {
            switch (categoryName)
            {
                case "meet":
                    cssClasses.Add("theme1");
                    break;
                case "track":
                    cssClasses.Add("theme2");
                    break;
                case "plan":
                    cssClasses.Add("theme3");
                    break;
                default:
                    break;
            }
        }

        return [.. cssClasses];
    }
}
