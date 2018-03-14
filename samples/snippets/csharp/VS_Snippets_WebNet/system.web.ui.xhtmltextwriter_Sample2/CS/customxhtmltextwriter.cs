// <snippet1>
using System;
using System.IO;
using System.Web;
using System.Security.Permissions;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls.Adapters;

namespace Samples.AspNet.CS
{
// <snippet5>
    // Create a class that inherits from XhtmlTextWriter.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal)] 
    public class CustomXhtmlTextWriter : XhtmlTextWriter
    {
        // Create two constructors, following 
        // the pattern for implementing a
        // TextWriter constructor.
        public CustomXhtmlTextWriter(TextWriter writer) : 
            this(writer, DefaultTabString)
        {
        }


        public CustomXhtmlTextWriter(TextWriter writer, string tabString) : 
            base(writer, tabString)
        {
        }
// </snippet5>


// <snippet2>        
        // Override the OnAttributeRender method to 
        // allow this text writer to render only eight-point 
        // text size.
        protected override bool OnAttributeRender(string name, 
          string value, 
          HtmlTextWriterAttribute key) 
        {
            if (key == HtmlTextWriterAttribute.Size)
            {
                if (String.Compare(value, "8pt") == 0)
                {
                    return true;
                }
                else
                {
                   return false;
                } 
             }
             else
             {
                 return base.OnAttributeRender(name, value, key);
             }

         }
// </snippet2>       
        
// <snippet3>        
        // Override the OnStyleAttributeRender
        // method to prevent this text writer 
        // from rendering purple text.
        protected override bool OnStyleAttributeRender(string name, 
            string value, 
            HtmlTextWriterStyle key)
        {
            if (key == HtmlTextWriterStyle.Color)
            {
                if (String.Compare(value, "purple") == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return base.OnStyleAttributeRender(name, value, key);
            }        
        }  
// </snippet3>

// <snippet4>        
        // Override the BeginRender method to write a
        // message and call the WriteBreak method
        // before a control is rendered.
        override public void BeginRender()
        {
           this.Write("A control is about to render.");
           this.WriteBreak();
        }
        
        // Override the EndRender method to
        // write a string immediately after 
        // a control has rendered. 
        override public void EndRender()
        {
           this.Write("A control just rendered.");
        }  
// </snippet4>
         
    }
}
// </snippet1>
