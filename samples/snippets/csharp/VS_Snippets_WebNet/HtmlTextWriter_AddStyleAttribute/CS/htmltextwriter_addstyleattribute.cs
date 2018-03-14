/* 
 * The following example demonstrates the 'AddStyleAttribute(string, string)' method 
 * of 'HtmlTextWriter' class.
 * 
 * In this program a custom web control called 'FirstControl' is shown. It has 
 * one property called the 'Message'. The 'Render' method has been overriden to
 * write the html contents with reference to this control. This contents are 
 * written to the final .aspx page in which this control is inserted. The 'Render'
 * method displays the contents of the 'Message' property followed by the current
 * time on the server were the corresponding .aspx page resides. 
 * 
 * Note : Follow the instructions in HtmlTextWriterReadme.txt for details on installing
 *        a site that uses custom controls.  
 */

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace CustomControls
{

    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class FirstControl : WebControl
    {
        // The message property.
        private String message = "Hello";

        // Accessors for the message property.
        public virtual String Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
// <snippet1>
            // Add style attribute for 'p'(paragraph) element.
            writer.AddStyleAttribute("font-size", "12pt");
            writer.AddStyleAttribute("color", "fuchsia");
            // Output the 'p' (paragraph) element with the style attributes.
            writer.RenderBeginTag("p");
            // Output the 'Message' property contents and the time on the server.
            writer.Write(Message + "<br>" +
                "The time on the server: " +
                System.DateTime.Now.ToLongTimeString());

            // Close the element.
            writer.RenderEndTag();
// </Snippet1>
        }
    }

}
