using System;
using System.IO;
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
    public class MyPage : Page
    {
        protected override HtmlTextWriter CreateHtmlTextWriter(TextWriter writer)
        {
            return new htwFour(writer);
        }
    }

    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class htwFour : HtmlTextWriter
    {
        public htwFour(TextWriter writer)
            : base(writer)
        {
        }

        public htwFour(TextWriter writer, string tabString)
            : base(writer, tabString)
        {
        }
// <Snippet1>
        // Override the RenderBeforeTag method to add the 
        // opening tag of a Font element before the 
        // opening tag of any Label elements rendered by this 
        // custom markup writer. 
        protected override string RenderBeforeTag()
        {
            // Compare the TagName property value to the
            // string label to determine whether the element to 
            // be rendered is a Label. If it is a Label,
            // the opening tag of the Font element, with a Color
            // style attribute set to red, is added before
            // the Label.
            if (String.Compare(TagName, "label") == 0)
            {
                return "<font color=\"red\">";
            }
            // If a Label is not being rendered, use 
                // the base RenderBeforeTag method.
            else
            {
                return base.RenderBeforeTag();
            }
        }
// </snippet1>

// <Snippet2>
        // Override the RenderAfterTag method to add the 
        // closing tag of the Font element after the 
        // closing tag of a Label element has been rendered.
        protected override string RenderAfterTag()
        {
            // Compare the TagName property value to the
            // string label to determine whether the element to 
            // be rendered is a Label. If it is a Label,
            // the closing tag of a Font element is rendered
            // after the closing tag of the Label element.
            if (String.Compare(TagName, "label") == 0)
            {
                return "</font>";
            }
            // If a Label is not being rendered, use 
                // the base RenderAfterTag method.
            else
            {
                return base.RenderAfterTag();
            }
        }
// </snippet2>
    }


    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class ctlMessage : WebControl
    {
        // The message property.
        private String myMessage = "Hello";

        // Accessors for the message property.
        public virtual String Message
        {
            get
            {
                return myMessage;
            }
            set
            {
                myMessage = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            // Write the contents of the control.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write(Message);
            writer.RenderEndTag();
            writer.Write("<br>" + "The time on the server: " + System.DateTime.Now.ToLongTimeString());
        }
    }
}