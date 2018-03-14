<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Details page for DataGrid</title>
<script runat="server">
 
      Sub Page_Load(sender As Object, e As EventArgs) 
      
         Label1.Text = "You selected item: " & Request.QueryString("id")
      
      End Sub
 
   </script>
 
</head>
<body>
 
   <h3>Details page for DataGrid</h3>
 
   <asp:Label id="Label1"
        runat="server"/>
 
</body>
</html>

<!--</Snippet1>-->