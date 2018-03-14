using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS
{
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class SimpleButton : Control
    {

        public override void RenderControl(HtmlTextWriter writer)
        {

            // Create an input button using
            // the HtmlTextWriter class.
            writer.Write(HtmlTextWriter.TagLeftChar);
            writer.Write("input");
            writer.WriteAttribute("type", "button");
            writer.WriteAttribute("value", "This is a button.");

// <snippet7>
            // Create some styles for the button.
            writer.Write(HtmlTextWriter.SpaceChar);
            writer.Write("style");
            writer.Write(HtmlTextWriter.EqualsDoubleQuoteString);
            writer.Write("font-size");
            writer.Write(HtmlTextWriter.StyleEqualsChar);
            writer.Write("12pt");
            writer.Write(HtmlTextWriter.SemicolonChar);
            writer.Write("border-style");
            writer.Write(HtmlTextWriter.StyleEqualsChar);
            writer.Write("ridge");
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
// </snippet7>

            // Write a closing slash for the markup element.
            writer.Write(HtmlTextWriter.SelfClosingChars);
            writer.Write(HtmlTextWriter.TagRightChar);
        }

    }
}