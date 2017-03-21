namespace Samples.AspNet.CS.Controls
{

    /// <summary>
    /// Summary description for source
    /// </summary>
    public class MyCatalogPartChrome : CatalogPartChrome
    {
        public MyCatalogPartChrome(CatalogZoneBase zone)
            : base(zone)
        {

        }

        protected override Style  CreateCatalogPartChromeStyle(CatalogPart catalogPart, PartChromeType chromeType)
        {
            Style catalogStyle = base.CreateCatalogPartChromeStyle(catalogPart, chromeType);
            catalogStyle.BackColor = Color.Bisque;
            return catalogStyle;
        }

        public override void PerformPreRender()
        {
            Style zoneStyle = new Style();
            zoneStyle.BackColor = Color.Cornsilk;

            Zone.Page.Header.StyleSheet.RegisterStyle(zoneStyle, null);
            Zone.MergeStyle(zoneStyle);
        }

        protected override void  RenderPartContents(HtmlTextWriter writer, CatalogPart catalogPart)
        {
            writer.AddStyleAttribute("color", "red");
            writer.RenderBeginTag("p");
            writer.Write("Apply all changes");
            writer.RenderEndTag();
            catalogPart.RenderControl(writer);
        }

        public override void  RenderCatalogPart(HtmlTextWriter writer, CatalogPart catalogPart)
        {
            base.RenderCatalogPart(writer, catalogPart);
        }
    }

    public class MyCatalogZone : CatalogZone
    {
        protected override CatalogPartChrome  CreateCatalogPartChrome()
        {
            return new MyCatalogPartChrome(this);
        }
    }
}