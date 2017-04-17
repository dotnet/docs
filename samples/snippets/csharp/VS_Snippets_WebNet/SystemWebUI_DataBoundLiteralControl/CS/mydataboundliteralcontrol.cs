/*File name: myDataBoundLiteralControl.cs */

// <Snippet1>   

using System;
using System.Web;
using System.Web.UI;

namespace Samples.AspNet.CS.Controls 
{

   public class MyControl : Control 
   {
 
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
    protected override void Render(HtmlTextWriter output) 
    {
      // Checks if a DataBoundLiteralControl object is present.
      if ( (HasControls()) && (Controls[0] is DataBoundLiteralControl) ) 
      {
        // Obtains the DataBoundLiteralControl instance.
        DataBoundLiteralControl boundLiteralControl = (DataBoundLiteralControl)Controls[0];
        // Retrieves the text in the boundLiteralControl object.
        String text = boundLiteralControl.Text;
        output.Write("<h4>Your Message: " +text+"</h4>");

      }
    }
   }    
}

// </Snippet1>

