// <Snippet1>
using System;
using System.Web.UI;
using System.Collections;
using System.Collections.Specialized;

namespace CustomControls {

   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]   
   public class MyButton: Control, IPostBackEventHandler {
      
      // Defines the Click event.
      public event EventHandler Click;
      
      //Invoke delegates registered with the Click event.
      protected virtual void OnClick(EventArgs e) {
         
         if (Click != null) {
            Click(this, e);
         }   
      }
      
      
      // Define the method of IPostBackEventHandler that raises change events.
      public void RaisePostBackEvent(string eventArgument){
         
         OnClick(new EventArgs());
      }
      
      
      protected override void Render(HtmlTextWriter output) {
         output.Write("<INPUT TYPE = submit name = " + this.UniqueID + 
            " Value = 'Click Me' />");   
      }
   }    
}
   
// </Snippet1>
