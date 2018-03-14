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
    public class WriteLineContent : WebControl
    {  
             
        public override void RenderControl(HtmlTextWriter writer)
        {             
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Blue");
            writer.RenderBeginTag(HtmlTextWriterTag.Font);
// <snippet1>
            // Use the WriteLine(string, object) method to
            // render a formatted string and an object in it.
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.WriteLine("The current cultural settings are {0}",
                CultureInfo.CurrentCulture);
            writer.RenderEndTag();
// </snippet1>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
             
// <snippet2>
             // Use the WriteLine(string,object,object) method to
             // render a formatted string and two objects 
             // in the string.
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.WriteLine("The current cultural settings are {0}. Today's date is {1}.",
                 CultureInfo.CurrentCulture, DateTime.Today);
             writer.RenderEndTag();
// </snippet2>

             writer.RenderBeginTag(HtmlTextWriterTag.Br);
             writer.RenderEndTag();
              
// <snippet3>
             // Use the WriteLine(Double) method to render
             // the MaxValue field of the Double structure. 
             writer.RenderBeginTag(HtmlTextWriterTag.Label);
             writer.WriteLine(Double.MaxValue);
             writer.RenderEndTag();
// </snippet3>

            writer.RenderBeginTag(HtmlTextWriterTag.Br);
            writer.RenderEndTag();
             
// <snippet4>
             // Use the WriteLine method to render an arbitrary
             // object, in this case a CutltureInfo object.
             writer.RenderBeginTag(HtmlTextWriterTag.B);
             writer.WriteLine(CultureInfo.CurrentCulture);
             writer.RenderEndTag();
// </snippet4>

             writer.RenderBeginTag(HtmlTextWriterTag.Br);
             writer.RenderEndTag();
             
// <snippet9>
             // Use the WriteLine(Single) method to render the
             // Epsilon field of the Single structure.
             writer.RenderBeginTag(HtmlTextWriterTag.B);
             writer.WriteLine(Single.Epsilon);
             writer.RenderEndTag();
// </snippet9>


             writer.RenderEndTag();
             writer.WriteLine();        
        }
    }
}