
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly:TagPrefix("CustomControls", "custom")]


namespace CustomControls
{

	// Simple custom control
	public class MyCS_Control : Control
      {
            private String message = "Hello";
            
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
            
            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
            protected override void Render( HtmlTextWriter writer)
            {
            writer.Write("<span style='background-color:aqua; font:8pt tahoma, verdana;'> "
                        + this.Message + "<br>" + "C# version. The time on the server is " + System.DateTime.Now.ToLongTimeString()
                        + "</span>");
                  
            }
      
      }

}
