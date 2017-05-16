// <snippet1>

using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS
{
// <snippet10>

    // A custom class that overrides its CreateHtmlTextWriter method.
    // This page uses the HtmlStyledLabelWriter class to render its content.
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyPage : Page
    {
        protected override HtmlTextWriter CreateHtmlTextWriter(TextWriter writer)
        {
            return new HtmlStyledLabelWriter(writer);
        }

    }
// </snippet10>

    // Create a custom class markup writer class that
    // overrides two versions of the RenderBeginTag 
    // method and one version of the RenderEndTag method.
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class HtmlStyledLabelWriter : HtmlTextWriter
    {
        private TextWriter writer;

        public HtmlStyledLabelWriter(TextWriter writer)
            : base(writer)
        {
            this.writer = writer;
        }

        public HtmlStyledLabelWriter(TextWriter writer, string tabString)
            : base(writer, tabString)
        {
            this.writer = writer;
        }

// <snippet2>
        public override void RenderBeginTag(HtmlTextWriterTag tagKey)
        {  

// <snippet3>
// <snippet4>
            // If the markup element being rendered is a Label,
            // render the opening tag of a Font element before it.
            if (tagKey == HtmlTextWriterTag.Label)
            {
                // Check whether a Color style attribute is 
                // included on the Label. If not, use the
                // AddStyleAttribute and GetStyleName methods to add one
                // and set its value to red.
                if (!IsStyleAttributeDefined(HtmlTextWriterStyle.Color))
                {
                    AddStyleAttribute(GetStyleName(HtmlTextWriterStyle.Color), "red");
                }
// </snippet4>
                Write(TagLeftChar);
// <snippet5>
                // Use the GetTagName method to associate 
                // the Font element with its HtmlTextWriteTag
                // enumeration value in a Write method call.
                Write(GetTagName(HtmlTextWriterTag.Font));
// </snippet5>
                Write(SpaceChar);
// <snippet6>
                // Use the GetAttributeName method to associate 
                // the Size attribute with its HtmlTextWriteAttribute
                // enumeration value in a Write method call.
                Write(GetAttributeName(HtmlTextWriterAttribute.Size));
// </snippet6>
                Write(EqualsChar);
                Write(DoubleQuoteChar);
                Write("30pt");
                Write(DoubleQuoteChar);
                Write(TagRightChar);

// <snippet7>
                // Close the Font element.
                Write(GetTagName(HtmlTextWriterTag.Font));
// </snippet7>
            }
// </snippet3>

            // Call the base class's RenderBeginTag method.
            base.RenderBeginTag(tagKey);
        }
// </snippet2>

// <snippet8>
        public override void RenderBeginTag(string tagName)
        {
            // Call the overloaded RenderBeginTag(HtmlTextWriterTag)
            // method.
            RenderBeginTag(GetTagKey(tagName));
        }
// </snippet8>

// <snippet9>
        public override void RenderEndTag()
        {
            // Call the RenderEndTag method of the base class.
            base.RenderEndTag();

            // If the element being rendered is a Label, 
            // call the PopEndTag method to write its closing tag.
            if (TagKey == HtmlTextWriterTag.Label)
            {
                Write(PopEndTag());
            }
        }
// </snippet9>
    }
}
// </snippet1>