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
    public class SimpleTable : WebControl
    {
        const int maxRows = 3;
        const int maxCols = 5;

// <snippet1>
        // Override the RenderControl method to create a simple table.
        public override void RenderControl(HtmlTextWriter writer)
        {

// <snippet2>
// <snippet9>
            // Create the opening tag of a table element
            // with styles by using the HtmlTextWriter class.
            writer.Write(HtmlTextWriter.TagLeftChar);
            writer.Write("table");
// </snippet9>

// <snippet5>
            // Write a space and a FontWeight
            // attribute to the tag.
            writer.Write(HtmlTextWriter.SpaceChar);
            writer.Write("FontWeight");

            // Set the FontWeight attribute to Bold.
            writer.Write(HtmlTextWriter.StyleEqualsChar);
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
            writer.Write("bold");
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
// </snippet5>

            writer.Write(HtmlTextWriter.SpaceChar);

            // Write the FontSize attribute and set it to
            // 14pt.
            writer.Write("FontSize");
            writer.Write(HtmlTextWriter.StyleEqualsChar);
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
            writer.Write("14pt");
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
            writer.Write(HtmlTextWriter.SpaceChar);

// <snippet6>
            // Create a border attribute for the table,
            // and set it to 1.
            writer.Write("border");
            writer.Write(HtmlTextWriter.EqualsDoubleQuoteString);
            writer.Write("1");
            writer.Write(HtmlTextWriter.DoubleQuoteChar);
// </snippet6>

            // Write the last character of the table's 
            // opening tag.
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteLine();
// </snippet2>

            // Indent for child elements for the table.
            writer.Indent++;

// <snippet3>
            // Create the number of <tr> elements
            // specified in the maxRows constant.
            for (int i = 0; i < maxRows; i++)
            {

                writer.WriteFullBeginTag("tr");
                writer.WriteLine();

                writer.Indent++;

                // In each row create the number of
                // <td> elements specified in the
                // maxCols constant.
                for (int j = 0; j < maxCols; j++)
                {

                    writer.WriteBeginTag("td");
                    writer.WriteAttribute("valign", "top");
                    writer.WriteAttribute("bgcolor", "lightblue");
                    writer.Write(HtmlTextWriter.TagRightChar);

                    writer.Write("Cell (" + i.ToString() + "," + j.ToString() + ")");

                    writer.WriteEndTag("td");
                    writer.WriteLine();
                }

                writer.Indent--;
                writer.WriteEndTag("tr");
                writer.WriteLine();
            }
// </snippet3>
            writer.Indent--;

// <snippet4>
            // Write the closing tag of a table element.
            writer.Write(HtmlTextWriter.EndTagLeftChars);
            writer.Write("table");
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteLine();
// </snippet4>

        }
// </snippet1>
    }
}

