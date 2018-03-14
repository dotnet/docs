using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

// <Snippet2>
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

        // <Snippet3>
        protected override Style  CreateCatalogPartChromeStyle(CatalogPart catalogPart, PartChromeType chromeType)
        {
            Style catalogStyle = base.CreateCatalogPartChromeStyle(catalogPart, chromeType);
            catalogStyle.BackColor = Color.Bisque;
            return catalogStyle;
        }
        // </Snippet3>

        // <Snippet4>
        public override void PerformPreRender()
        {
            Style zoneStyle = new Style();
            zoneStyle.BackColor = Color.Cornsilk;

            Zone.Page.Header.StyleSheet.RegisterStyle(zoneStyle, null);
            Zone.MergeStyle(zoneStyle);
        }
        // </Snippet4>

        // <Snippet5>
        protected override void  RenderPartContents(HtmlTextWriter writer, CatalogPart catalogPart)
        {
            writer.AddStyleAttribute("color", "red");
            writer.RenderBeginTag("p");
            writer.Write("Apply all changes");
            writer.RenderEndTag();
            catalogPart.RenderControl(writer);
        }
        // </Snippet5>

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
// </Snippet2>