// <Snippet1>
// The following class creates a custom ASP.NET server control that implements
// the IAttributeAccessor interface. It creates a MyTextBox class that contains
// Width and Text properties that get and set their values from view state.
// Pages that use this control create an instance of this control and set the
// Width property using the IAttributeAccessor.SetAttribute method. 
// The page then displays the values of the Text and Width properties 
// using the IAttributeAccessor.GetAttribute method.
// When compiled, this assembly is named MyAttributeAccessor.
using System;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;

namespace AttributeAccessor
{
   [AspNetHostingPermission(SecurityAction.Demand, 
      Level=AspNetHostingPermissionLevel.Minimal)]
   public sealed class MyTextBox : Control, IAttributeAccessor
   {
      // Declare the Width property.
      public String Width
      {
         get
         {
            return (String)ViewState["Width"];
         }
         set
         {
            ViewState["Width"] = value;
         }
      }

      // Declare the Text property.
      public String Text
      {
         get
         {
            return (String)ViewState["Text"];
         }
         set
         {
            ViewState["Text"] = value;
         }
      }
      // <snippet2>
      // Implement the SetAttribute method for the control. When
      // this method is called from a page, the control's properties
      // are set to values defined in the page.
      public void SetAttribute(String name, String value1)
      {
         ViewState[name] = value1;
      }
      // </snippet2>

      // <snippet3>
      // Implement the GetAttribute method for the control. When
      // this method is called from a page, the values for the control's
      // properties can be displayed in the page.
      public String GetAttribute(String name)
      {
         return (String)ViewState[name];
      }
      // </snippet3>

      protected override void Render(HtmlTextWriter output)
      {
         output.Write("<input type=text id= " + this.UniqueID);
         output.Write(" Value='" + this.Text);
         output.Write("' Size=" + this.Width + ">");
      }
   }
}
// </Snippet1>
