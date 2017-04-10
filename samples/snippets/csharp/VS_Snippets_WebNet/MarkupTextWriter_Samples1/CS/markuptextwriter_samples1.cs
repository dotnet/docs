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
    public class SampleMarkupControl : Control
    {        
// <snippet1>
        // Overrides the Render method to write a <span> element
        // that applies styles and attributes. 
        protected override void Render(HtmlTextWriter writer) 
        {     
// <snippet2>
            // Set attributes and values along with attributes and styles  
            // attribute defined for a <span> element.
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "alert('Hello');");
            writer.AddAttribute("CustomAttribute", "CustomAttributeValue");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Red");
            writer.AddStyleAttribute("Customstyle", "CustomStyleValue");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            // Create a space and indent the markup inside the 
            // <span> element.
            writer.WriteLine();
            writer.Indent++;
// </snippet2>
            writer.Write("Hello");
            writer.WriteLine();
            
// <snippet3>
            // Controls the encoding of markup attributes
            // for an <img> element. Simple known values 
	        // do not need encoding.
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, 
                "Encoding, \"Required\"", 
                true);
            writer.AddAttribute("myattribute", 
                "No &quot;encoding &quot; required", 
                false);
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
            writer.WriteLine();
// </snippet3>

// <snippet4>
            // Create a non-standard markup element.
            writer.RenderBeginTag("MyTag");
            writer.Write("Contents of MyTag");
            writer.RenderEndTag();
            writer.WriteLine();
// </snippet4>

// <snippet5>
            // Create a manually rendered <img> element
            // that contains an alt attribute.
            writer.WriteBeginTag("img");
            writer.WriteAttribute("alt", "A custom image.");
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteEndTag("img");
// </snippet5>
            writer.WriteLine();

            writer.Indent--;
            writer.RenderEndTag();

        }
// </snippet1>
    }
	 

}

