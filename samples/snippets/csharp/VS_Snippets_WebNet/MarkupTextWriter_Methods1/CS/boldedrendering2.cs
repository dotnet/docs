using System;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS
{

    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)] 
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    public class WriteContent : WebControl
    {                                              
        
        public override void RenderControl(HtmlTextWriter writer)
        {
             writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Blue");
             writer.RenderBeginTag(HtmlTextWriterTag.Font);


// <snippet5>
             // Use the Write(string, object) method to
             // render a formatted string and an object in it.
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.Write("The current cultural settings are {0}",
                 CultureInfo.CurrentCulture);
             writer.RenderEndTag();
// </snippet5>

             writer.RenderBeginTag(HtmlTextWriterTag.Br);
             writer.RenderEndTag();
             
// <snippet6>
             // Use the Write(string,object,object) method to
             // render a formatted string and two objects 
             // in the string.
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.Write("The current cultural settings are {0}. Today's date is {1}.",
                 CultureInfo.CurrentCulture, DateTime.Today);
             writer.RenderEndTag();
// </snippet6>

             writer.RenderBeginTag(HtmlTextWriterTag.Br);
             writer.RenderEndTag();
              
// <snippet7>
             // Use the Write(Double) method to render
             // the MaxValue field of the Double structure. 
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.Write(Double.MaxValue);
             writer.RenderEndTag();
// </snippet7>

             writer.RenderBeginTag(HtmlTextWriterTag.Br);
             writer.RenderEndTag();
             
// <snippet8>
             // Use the Write method to render an arbitrary
             // object, in this case a CultureInfo object. 
             writer.Write("This is a rendered CultureInfo Object.");
             writer.RenderBeginTag(HtmlTextWriterTag.B);
             writer.Write(CultureInfo.CurrentCulture);
             writer.RenderEndTag();
// </snippet8>

             writer.RenderBeginTag(HtmlTextWriterTag.Br);
             writer.RenderEndTag();

// <snippet10>
             // Use the Write(Single) method to render the
             // Epsilon field of the Single structure. 
             writer.RenderBeginTag(HtmlTextWriterTag.B);
             writer.Write(Single.Epsilon);
             writer.RenderEndTag();
// </snippet10>

             writer.RenderEndTag();
             writer.WriteLine();
   
        }
    }
}
