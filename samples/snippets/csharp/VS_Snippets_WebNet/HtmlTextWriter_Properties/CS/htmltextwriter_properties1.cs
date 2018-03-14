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
    public class FirstControl : WebControl
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

// <snippet1>
        // Override a control's Render method to determine what it
        // displays when included in a Web Forms page.
        protected override void Render(HtmlTextWriter writer)
        {
// <snippet2>
            // Get the value of the current markup writer's 
            // Encoding property, convert it to a string, and 
            // write it to the markup stream.
            writer.Write("Encoding : " + writer.Encoding.ToString() + "<br>");
// </snippet2>      

// <snippet3>
            // Write the opening tag of a Font element.
            writer.WriteBeginTag("font");
            // Write a Color style attribute to the opening tag
            // of the Font element and set its value to red.
            writer.WriteAttribute("color", "red");
            // Write the closing character for the opening tag of
            // the Font element.
            writer.Write('>');

            // Use the InnerWriter property to create a TextWriter
            // object that will write the content found between
            // the opening and closing tags of the Font element.
            // Message is a string property of the control that 
            // overrides the Render method.
            TextWriter innerTextWriter = writer.InnerWriter;
            innerTextWriter.Write(Message + "<br> The time on the server :" + System.DateTime.Now.ToLongTimeString());

            // Write the closing tag of the Font element.
            writer.WriteEndTag("font");
        }
// </snippet3>
    }
// </snippet1>
}
