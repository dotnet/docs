// <snippet1>
// Create a simple class, named StringEncoder,
// that performs markup and URL encoding of strings.
using System;
using System.Web;
using System.Security.Permissions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS
{
    [AspNetHostingPermission(SecurityAction.Demand,
        Level=AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level=AspNetHostingPermissionLevel.Minimal)] 
    public class StringEncoder : WebControl
    {      
        protected override void Render(HtmlTextWriter writer)
        {
            // Create variables and assign them values.
            string url;
            string param;
            string colHeads;
// <snippet2>         
            // Assign a value to a string variable,
            // encode it, and write it to a page.
            colHeads = "<custID> & <invoice#>"; 
            writer.WriteEncodedText(colHeads);
            writer.WriteBreak();
// </snippet2>
  
// <snippet3>          
            // Assign a value to a string variable
            // and URL-encode it to a page.
            url = "http://localhost/SampleFolder/Sample + File.txt"; 
            writer.WriteBreak();
            writer.WriteEncodedUrl(url);
            writer.WriteBreak();
// </snippet3>
  
// <snippet4> 
            // Assign a value to a string variable
            // and encode it to a page as a 
            // URL parameter.      
            param = "ID=City State";
            writer.WriteBreak();
            writer.WriteEncodedUrlParameter(param);
// </snippet4>
        }
    }
}
// </snippet1>
