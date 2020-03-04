<!-- <Snippet2> -->
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

      <asp:ListBox id="list"
           runat="server">
       
         <asp:ListItem Value="Australia">Australia</asp:ListItem>
         <asp:ListItem Selected="True" Value="NoCountry">--ChooseCountry--</asp:ListItem>
         <asp:ListItem Value="USA">USA</asp:ListItem>
       
      </asp:ListBox>
 
      <asp:RequiredFieldValidator id="valList"
           ForeColor="#FF0000"
           ErrorMessage="Selection Invalid!"
           ControlToValidate="list"
           InitialValue="NoCountry"
           EnableClientScript="False"
           runat="server"/>

      <br />

      <asp:Button id="Button1"
           Text="Submit"
           runat="server"/>

   </form>
 
</body>
</html>
<!-- </Snippet2> -->

