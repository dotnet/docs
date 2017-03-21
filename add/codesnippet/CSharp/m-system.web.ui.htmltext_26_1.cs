
    // A custom class that overrides its CreateHtmlTextWriter method.
    // This page uses the HtmlStyledLabelWriter class to render its content.
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyPage : Page
    {
        protected override HtmlTextWriter CreateHtmlTextWriter(TextWriter writer)
        {
            return new HtmlStyledLabelWriter(writer);
        }

    }