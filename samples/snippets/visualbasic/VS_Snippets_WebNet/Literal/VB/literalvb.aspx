<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Literal Example</title>
<script runat="server">

      Sub ButtonClick(sender As Object, e As EventArgs)
      
         Literal1.Text="Welcome to ASP.NET!!"
      
      End Sub

   </script>

</head>
<body>
   <form id="form1" runat="server">
      <h3>Literal Example</h3>

      <asp:Literal id="Literal1"
           Text="Hello World!!"
           runat="server"/>

      <br /><br />

      <asp:Button id="Button1"
           Text="Change Literal Text"
           OnClick="ButtonClick"
           runat="server"/>

   </form>
</body>
</html>

<!--</Snippet1>-->
