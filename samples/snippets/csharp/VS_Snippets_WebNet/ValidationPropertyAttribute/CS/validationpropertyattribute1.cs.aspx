<%@ Page language="c#" %>
<%@ Register TagPrefix="mymessage" Namespace="MyControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">
// System.Web.UI.ValidationPropertyAttribute.Name

/* The following example demonstrates the property 'Name' of class 'ValidationPropertyAttribute'
   This also functions as a client to test the custom control developed in ValidationPropertyAttribute1.cs
*/

// <Snippet2>
   void Page_Load(object sender, System.EventArgs e)
    {
  // Display the 'Name' property of ValidationPropertyAttribute applied to MessageControl.
  foreach(object attribute in (typeof(MyControls.MessageControl)).GetCustomAttributes(true))
      {
         if(attribute is ValidationPropertyAttribute)
         {
            Response.Write("The name of the property to expose for input validation is : " + ((ValidationPropertyAttribute)attribute).Name);
         }
      }
    }
// </Snippet2>
   void myButton_Click(object sender,System.EventArgs e)
   {
myRangeValidator.Type = ValidationDataType.Integer;
myRangeValidator.Validate();
if (Page.IsValid) 
   {
      lblOutput.Text = "Value = " + myControl1.Message + "Result: Valid!";
   }
   else 
   {
      lblOutput.Text = "Value = " + myControl1.Message + "Result: Not valid!";
   }
   }  
   
   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
</head>
   <body>
      <form id="form1" runat="server">
         <mymessage:MessageControl id="myControl1" Message="150" Text="MessageControl" runat="server" />
         <asp:RangeValidator id="myRangeValidator" ControlToValidate="myControl1" MinimumValue="0" MaximumValue="50" runat="server" />
         <br />
         <asp:Button id="myButton" Text="Validate" OnClick="myButton_Click" runat="server" />
         <br />
         <asp:Label id="lblOutput" runat="server" />
      </form>
   </body>
</html>
