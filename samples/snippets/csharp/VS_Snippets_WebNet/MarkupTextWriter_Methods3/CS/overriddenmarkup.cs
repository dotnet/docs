using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS
{

    // Create a custom MarkupTextWriter class that 
    // overrides the OnTagRender, OnAttributeRender, and
    // OnStyleAttributeRender methods.    
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class SimpleHtmlTextWriter : HtmlTextWriter
    {
// <snippet1>
        // Create a markup class constructor that uses the
        // DefaultTabString property to establish indent settings
        // for the writer.
        public SimpleHtmlTextWriter(TextWriter writer)
            :
            this(writer, DefaultTabString)
        {
        }
// </snippet1>

// <snippet3>
        // Create a constructor that calls the base class's constructor.
        public SimpleHtmlTextWriter(TextWriter writer, string tabString)
            :
            base(writer, tabString)
        {
        }
// </snippet3>


// <snippet4>
        // If a <font> element is to be rendered, check whether it contains
        // a size attribute. If it does not, add one and set its value to
        // 20 points, then return true.
        protected override bool OnTagRender(string name, HtmlTextWriterTag key)
        {

            if (key == HtmlTextWriterTag.Font)
            {
                if (!(IsAttributeDefined(HtmlTextWriterAttribute.Size)))
                {
                    AddAttribute(HtmlTextWriterAttribute.Size, "20pt");
                    return true;
                }
            }

            // If the element is not a <font> element, use
            // the base functionality of the OnTagRenderMethod.
            return base.OnTagRender(name, key);
        }
// </snippet4>

// <snippet5>
        // If a size attribute is to be rendered, compare its value to 30 point.
        // If it is not set to 30 point, add the attribute and set the value to 30,
        // then return false.
        protected override bool OnAttributeRender(string name,
            string value,
            HtmlTextWriterAttribute key)
        {

            if (key == HtmlTextWriterAttribute.Size)
            {
                if (string.Compare(value, "30pt") != 0)
                {
                    AddAttribute("size", "30pt");
                    return false;
                }
            }

            // If the attribute is not a size attribute, use
            // the base functionality of the OnAttributeRender method.
            return base.OnAttributeRender(name, value, key);
        }
// </snippet5>

// <snippet6>
        // If a color style attribute is to be rendered,
        // compare its value to purple. If it is not set to
        // purple, add the style attribute and set the value
        // to purple, then return false.
        protected override bool OnStyleAttributeRender(string name,
            string value,
            HtmlTextWriterStyle key)
        {

            if (key == HtmlTextWriterStyle.Color)
            {
                if (string.Compare(value, "purple") != 0)
                {
                    AddStyleAttribute("color", "purple");
                    return false;
                }
            }

            // If the style attribute is not a color attribute,
            // use the base functionality of the
            // OnStyleAttributeRender method.
            return base.OnStyleAttributeRender(name, value, key);
        }
// </snippet6>
    }
}
