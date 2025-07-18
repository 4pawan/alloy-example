using System.ComponentModel.DataAnnotations;

namespace alloy_example.Models.Pages;

/// <summary>
/// Used for campaign or landing pages, commonly used for pages linked in online advertising such as AdWords
/// </summary>
[SiteContentType(
   GUID = "DBED4258-8213-48DB-A11F-99C034172A54",
   GroupName = Globals.GroupNames.Specialized)]
[SiteImageUrl]
public class LandingPage : SitePageData
{
    [Display(
        GroupName = SystemTabNames.Content,
        Order = 310)]
    [CultureSpecific]
    public virtual ContentArea MainContentArea { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);

        HideSiteFooter = true;
        HideSiteHeader = true;
    }
}
