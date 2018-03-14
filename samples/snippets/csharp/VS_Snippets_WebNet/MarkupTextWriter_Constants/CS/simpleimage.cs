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
    public class SimpleImage : WebControl
    {

        private string fileValue;

        public string FileName
        {
            get
            {
                return fileValue;
            }

            set
            {
                fileValue = value;
            }

        }

// <snippet8>
        public override void RenderControl(HtmlTextWriter writer)
        {

            // Create an <img> element using members 
            // of the HtmlTextWriter class.
            writer.WriteBeginTag("img");
            writer.Write(HtmlTextWriter.SpaceChar);

// <snippet10>
            // Write the src attribute and the path
            // for the image file.
            writer.Write("src");
            writer.Write(HtmlTextWriter.EqualsChar);
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
            writer.Write(HtmlTextWriter.SlashChar);
            writer.Write("images");
            writer.Write(HtmlTextWriter.SlashChar);
// </snippet10>
 
// <snippet11>
            // Write the name of the image file from the 
            // FileName property, close the path, and then
            // close the <img> element.
            writer.Write(FileName);
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
            writer.Write(HtmlTextWriter.SelfClosingTagEnd);
// </snippet11>
        }
// </snippet8>
    }
}


