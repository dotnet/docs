using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Security.Permissions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

// <Snippet2>
namespace Samples.AspNet.CS.Controls
{

    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyEditorPartChrome : EditorPartChrome
    {
        public MyEditorPartChrome(EditorZoneBase zone)
            : base(zone)
        {

        }
        
        // <Snippet3>
        protected override Style CreateEditorPartChromeStyle(EditorPart editorPart, PartChromeType chromeType)
        {
            Style editorStyle = base.CreateEditorPartChromeStyle(editorPart, chromeType);
            editorStyle.BackColor = Color.Bisque;
            return editorStyle;
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
        protected override void RenderPartContents(HtmlTextWriter writer, EditorPart editorPart)
        {
            writer.AddStyleAttribute("color", "red");
            writer.RenderBeginTag("p");
            writer.Write("Apply all changes");
            writer.RenderEndTag();
            editorPart.RenderControl(writer);
        }
        // </Snippet5>

        public override void RenderEditorPart(HtmlTextWriter writer, EditorPart editorPart)
        {
            base.RenderEditorPart(writer, editorPart);
        }
    }

    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyEditorZone : EditorZone
    {
        protected override EditorPartChrome CreateEditorPartChrome()
        {
            return new MyEditorPartChrome(this);
        }
    }
}
// </Snippet2>