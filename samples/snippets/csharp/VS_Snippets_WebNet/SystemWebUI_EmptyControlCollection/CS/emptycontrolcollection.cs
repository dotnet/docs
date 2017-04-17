
// <snippet1>

/* File name: emptyControlCollection.cs. */

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace CustomControls
{

  // Defines a simple custom control.
  public class MyCS_EmptyControl : Control
  {
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
    protected override ControlCollection CreateControlCollection() 
    /*
     * Function Name: CreateControlCollection.
     * Denies the creation of any child control by creating an empty collection.
     * Generates an exception if an attempt to create a child control is made.
     */
     {
       return new EmptyControlCollection(this);
     }
     
     [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
     protected override void CreateChildControls()
     /*
      * Function Name: CreateChildControls.
      * Populates the child control collection (Controls). 
      * Note: This function will cause an exception because the control does not allow 
      * child controls.
      */
      {
        // Create a literal control to contain the header and add it to the collection.
        LiteralControl text;
        text = new LiteralControl("<h5>Composite Controls</h5>");
        Controls.Add(text);
      }
   }

}
// </snippet1>


