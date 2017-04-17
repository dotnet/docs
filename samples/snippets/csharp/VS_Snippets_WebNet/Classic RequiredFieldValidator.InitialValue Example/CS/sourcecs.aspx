<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>RequiredFieldValidator InitialValue Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>RequiredFieldValidator InitialValue Example</h3>
 
      Name: 
      <asp:TextBox id="Text1" 
           Text="Enter a value" 
           runat="server"/>
 
      <asp:RequiredFieldValidator id="RequiredFieldValidator1" 
           InitialValue="Enter a value" 
           ControlToValidate="Text1"
           ErrorMessage="Required field!"
           runat="server"/>
 
      <br />
         
      <asp:Button id="Button1"
           Text="Validate" 
           runat="server"/>
 
   </form>
 
</body>
</html>
<!--</Snippet1>-->
