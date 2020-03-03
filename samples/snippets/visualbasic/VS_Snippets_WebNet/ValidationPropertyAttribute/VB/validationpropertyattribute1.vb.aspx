<%@ Page language="VB" %>
<%@ Register TagPrefix="mymessage" Namespace="MyControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">
' System.Web.UI.ValidationPropertyAttribute.Name

' The following example demonstrates the property 'Name' of class 'ValidationPropertyAttribute'
'   This also functions as a client to test the custom control developed in ValidationPropertyAttribute1.cs


' <Snippet2>     
   Sub Page_Load(Sender As Object, e As EventArgs)
Dim myAttribute As Object    
  'Display the 'Name' property of ValidationPropertyAttribute applied to MessageControl.
  For Each myAttribute In (GetType(MyControls.MessageControl)).GetCustomAttributes(true)
      
         If(myAttribute Is GetType(ValidationPropertyAttribute)) Then
                Response.Write("The name of the property to expose for input validation is : " + CType(myAttribute,ValidationPropertyAttribute).Name)
         End If
 Next
    End Sub
' </Snippet2>
   
   Sub myButton_Click(Sender As object, e As EventArgs )
   
myRangeValidator.Type = ValidationDataType.Integer
myRangeValidator.Validate()
If (Page.IsValid)  Then
  
      lblOutput.Text = "Value = " + myControl1.Message.ToString() + "Result: Valid!"
 
Else 
  
      lblOutput.Text = "Value = " + myControl1.Message.ToString() + "Result: Not valid!"
End If
   End Sub
   
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
