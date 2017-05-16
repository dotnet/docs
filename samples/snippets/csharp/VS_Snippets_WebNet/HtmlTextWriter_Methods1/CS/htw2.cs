// <snippet1>
// Create a custom HtmlTextWriter class that overrides 
// the RenderBeforeContent and RenderAfterContent methods.
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;

namespace HtmlTW2
{
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class cstmHtmlTW : HtmlTextWriter
    {
        public cstmHtmlTW(TextWriter writer)
            : base(writer)
        {

        }

        public cstmHtmlTW(TextWriter writer, string tabString)
            : base(writer, tabString)
        {

        }
// <snippet2>
        // Override the RenderBeforeContent method to write
        // a font element that applies red to the text in a Label element.
        protected override string RenderBeforeContent()
        {
            // Check to determine whether the element being rendered
            // is a label element. If so, render the opening tag
            // of the font element; otherwise, call the base method.
            if (TagKey == HtmlTextWriterTag.Label)
            {
                return "<font color=\"red\">";
            }
            else
            {
                return base.RenderBeforeContent();
            }
        }
// </snippet2>
// <snippet3>
        // Override the RenderAfterContent method to render
        // the closing tag of a font element if the 
        // rendered tag is a label element.
        protected override string RenderAfterContent()
        {
            // Check to determine whether the element being rendered
            // is a label element. If so, render the closing tag
            // of the font element; otherwise, call the base method.
            if (TagKey == HtmlTextWriterTag.Label)
            {
                return "</font>";
            }
            else
            {
                return base.RenderAfterContent();
            }
        }
// </snippet3>
    }
}
// </snippet1>