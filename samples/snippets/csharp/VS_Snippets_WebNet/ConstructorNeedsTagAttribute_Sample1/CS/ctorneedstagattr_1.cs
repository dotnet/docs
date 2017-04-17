using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Security.Permissions;

namespace CTorNeedsTagAtt 
{

// <Snippet1>

     // Attach the ConstructorNeedsTagAttribute to the custom Simple
     // class, which is derived from the WebControl class. This 
     // instance of the ConstructorNeedsTagAttribute class sets the
     // NeedsTag property to true.
     [ConstructorNeedsTagAttribute(true)]
     [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
     public sealed class Simple : WebControl 
     {
        private String NameTag = "";

        public Simple(String tag)
         {
               this.NameTag = tag;
         }         

         private String   UserMessage = null;

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
            output.Write("Testing the ConstructorNeedsTagAttribute Class.");
         }
   }      
// </Snippet1>
}

  