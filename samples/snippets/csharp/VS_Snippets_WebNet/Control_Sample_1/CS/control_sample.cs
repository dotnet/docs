// System.Web.UI.Control.CreateControlCollection; 
// System.Web.UI.Control.ChildControlsCreated;
// System.Web.UI.Control.RenderControl; System.Web.UI.Control.RenderChildren;

/* The following example demontrates implementation of methods 'RenderControl',
   'RenderChildren' and 'CreateControlCollection' with property 
   'ChildControlsCreated' of 'System.Web.UI.Control' class.    

   This program creates a custom control 'ParentControl' by inheriting from 
   'Control' Class. Method 'CreateChildControls' is overridden to create new child 
   controls. "Render" method is overridden to write the rendered content to client. 
   'RenderChildren' method is overridden for custom implementation of displaying 
   controls in reverse order. 
*/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RenderChildrenSample
{
   public class ParentControl:Control
   {
      private string _message = "Parent Control";
      
      public string Message
      {
         get
         {
            return _message;
         }
         set
         {
            _message = value;
         }
         
      }

// <Snippet1>
// <Snippet2>

      protected override void CreateChildControls()
      {               
         // Creates a new ControlCollection. 
         this.CreateControlCollection();

         // Create child controls.
          ChildControl firstControl = new ChildControl();
         firstControl.Message = "FirstChildControl";

         ChildControl secondControl = new ChildControl();
         secondControl.Message = "SecondChildControl";
         
         Controls.Add(firstControl);
         Controls.Add(secondControl);

         // Prevent child controls from being created again.
         ChildControlsCreated = true;
      }

// </Snippet2>
// </Snippet1>

// <Snippet3>
// <Snippet4>
      // Override default implementation to Render children according to needs. 
      protected override void RenderChildren(HtmlTextWriter output)
      {
         if (HasControls())
         {
            // Render Children in reverse order.
            for(int i = Controls.Count - 1; i >= 0; --i)
            {
               Controls[i].RenderControl(output);
            }
         }         
      }

      protected override void Render(HtmlTextWriter output)
      {       
         output.Write("<br>Message from Control : " + Message);       
         output.Write("Showing Custom controls created in reverse" +
                                                          "order");         
         // Render Controls.
         RenderChildren(output);
      }
// </Snippet4>
// </Snippet3>
   }

   public class ChildControl:Control
   {
      private string _message = "Child Control";
      public string Message
      {
         get
         {
            return _message;
         }
         set
         {
            _message = value;
         }         
      }
      
      protected override  void Render(HtmlTextWriter output)
      {
         output.Write("<br>Message from Control : " + Message);
      } 
   }
}
