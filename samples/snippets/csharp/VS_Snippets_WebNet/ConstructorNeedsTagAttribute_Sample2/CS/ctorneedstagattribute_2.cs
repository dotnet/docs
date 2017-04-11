using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Security.Permissions;

namespace MyUserControl 
{

// <Snippet1>      
    // Attach the ConstructorNeedsTagAttribute to the custom
    // SimpleControl, which is derived from WebControl. When
    // this version of the constructor is used, the NeedsTag
    // property is automatically set to false; therefore,
    // this class does not need a tag attribute.
    [ConstructorNeedsTagAttribute()] 
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    public sealed class SimpleControl : WebControl 
    {
    
         private String UserMessage=null;
    
         // Create a property named ControlValue.
         public String ControlValue 
         {
            get 
            {
               return UserMessage;
            }
            set 
            {
               UserMessage = value;
            }
          }
                
         protected override void Render(HtmlTextWriter output) 
         {
           output.Write("Testing the ConstructorNeedsTagAttribute class.");

        }
   }     
// </Snippet1>    

}

  