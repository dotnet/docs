<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>LinkButton Example</title>
<script language="VB" runat="server">
 
      Sub LinkButton_Click(sender As Object, e As EventArgs) 
         Label1.Text = "You clicked the link button"
      End Sub
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>LinkButton Example</h3>
 
      <asp:LinkButton id="LinkButton1" 
           Text="Click Me" 
           Font-Names="Verdana" 
           Font-Size="14pt" 
           OnClick="LinkButton_Click" 
           runat="server"/>
         
      <br />
 
      <asp:Label id="Label1" runat="server" />
         
   </form>
 
</body>
</html>

<!--</Snippet1>-->
