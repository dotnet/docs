/*
 *File Name: tagPrefixAttribute
 *Purpose: Show the use ot the TagPrefixAttribute class to define an assembly-level attribute that enables a control 
 *developer to specify a tag prefix alias for her custom controls. This attribute is used by tool such as Visual Studio.NET 
 *to automatically generate the following  Register directive in Web page where the custom control is used:
 * <%@ Register TagPrefix="tag prefix" Assembly="assembly name" Namespace="name space" %>.
 *This directive registers the tag prefix with a name space, moreover it specifies the assembly where the custom control 
 *code implementation resides. All this information is used by the runtime to allow the custom control compilation. With this 
 *directive in place, the user of your custom controls can include them in the Web page declaratively with the pre-specified 
 *tag prefix as follows: <tagprefix:controlname  runat = "server" /> 
 */



// <snippet1>

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

// </snippet1>


