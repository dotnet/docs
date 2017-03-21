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
        
        protected override Style CreateEditorPartChromeStyle(EditorPart editorPart, PartChromeType chromeType)
        {
            Style editorStyle = base.CreateEditorPartChromeStyle(editorPart, chromeType);
            editorStyle.BackColor = Color.Bisque;
            return editorStyle;
        }

        public override void PerformPreRender()
        {
            Style zoneStyle = new Style();
            zoneStyle.BackColor = Color.Cornsilk;

            Zone.Page.Header.StyleSheet.RegisterStyle(zoneStyle, null);
            Zone.MergeStyle(zoneStyle);
        }

        protected override void RenderPartContents(HtmlTextWriter writer, EditorPart editorPart)
        {
            writer.AddStyleAttribute("color", "red");
            writer.RenderBeginTag("p");
            writer.Write("Apply all changes");
            writer.RenderEndTag();
            editorPart.RenderControl(writer);
        }

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