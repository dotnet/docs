using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
 
// Create a custom markup writer class.
namespace Samples.AspNet.CS
{
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class HTW1 : HtmlTextWriter
    {
        public HTW1(TextWriter writer)
            : base(writer)
        {

        }

        public HTW1(TextWriter writer, string tabString)
            : base(writer, tabString)
        {

        }
// <snippet1>
        // Override the RenderBeginTag method to check whether
        // the tagKey parameter is set to a <label> element
        // or a <font> element.
        public override void RenderBeginTag(HtmlTextWriterTag tagKey)
        {

// <snippet2>
            // If the tagKey parameter is set to a <label> element
            // but a color attribute is not defined on the element,
            // the AddStyleAttribute method adds a color attribute
            // and sets it to red.
            if (tagKey == HtmlTextWriterTag.Label)
            {
                if (!IsStyleAttributeDefined(HtmlTextWriterStyle.Color))
                {
                    AddStyleAttribute(GetStyleKey("color"), "red");
                }
            }
// </snippet2>
// <snippet3>
            // If the tagKey parameter is set to a <font> element
            // but a size attribute is not defined on the element,
            // the AddStyleAttribute method adds a size attribute
            // and sets it to 30 point. 
            if (tagKey == HtmlTextWriterTag.Font)
            {
                if (!IsAttributeDefined(HtmlTextWriterAttribute.Size))
                {
                    AddAttribute(GetAttributeKey("size"), "30pt");
                }
            }
// </snippet3>
            // Call the base class's RenderBeginTag method
            // to ensure that this custom MarkupTextWriter
            // includes functionality for all other markup elements.
            base.RenderBeginTag(tagKey);
        }
// </snippet1>
 
// <snippet4>
        // Override the FilterAttributes method to check whether 
        // <label> and <anchor> elements contain specific attributes.      
        protected override void FilterAttributes()
        {
// <snippet5>
            // If the <label> element is rendered and a style
            // attribute is not defined, add a style attribute 
            // and set its value to blue.
            if (TagKey == HtmlTextWriterTag.Label)
            {
                if (!IsAttributeDefined(HtmlTextWriterAttribute.Style))
                {
                    AddAttribute("style", EncodeAttributeValue("color:blue", true));
                    Write(NewLine);
                    Indent = 3;
                    OutputTabs();
                }
            }
// </snippet5>

// <snippet6>
            // If an <anchor> element is rendered and an href
            // attribute has not been defined, call the AddAttribute
            // method to add an href attribute
            // and set it to http://www.cohowinery.com.
            // Use the EncodeUrl method to convert any spaces to %20.
            if (TagKey == HtmlTextWriterTag.A)
            {
                if (!IsAttributeDefined(HtmlTextWriterAttribute.Href))
                {
                    AddAttribute("href", EncodeUrl("http://www.cohowinery.com"));
                }
            }
// </snippet6>
            // Call the FilterAttributes method of the base class.
            base.FilterAttributes();
        }
// </snippet4>
// <snippet7>
        // Override the OutputTabs method to set the tab to
        // the number of spaces defined by the Indent variable.      
        protected override void OutputTabs()
        {
            // Output the DefaultTabString for the number
            // of times specified in the Indent property.
            for (int i = 0; i < Indent; i++)
                Write(DefaultTabString);
            base.OutputTabs();
        }
// </snippet7>
    }
}

