<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ImageButton CommandName Sample</title>
<script language="VB" runat="server">

      Sub ImageButton_Command(sender As Object, e As CommandEventArgs) 
         If (e.CommandName = "Sort") And (e.CommandArgument = "Ascending") Then
            Label1.Text = "You clicked the Sort Ascending Button"
         Else
            Label1.Text = "You clicked the Sort Descending Button"
         End If
      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>ImageButton CommandName Sample</h3>

      Click an image.<br /><br />

      <asp:ImageButton id="imagebutton1" runat="server"
           AlternateText="Sort Ascending"
           ImageUrl="images/pict.jpg"
           OnCommand="ImageButton_Command"
           CommandName="Sort"
           CommandArgument="Ascending"/>

      <asp:ImageButton id="imagebutton2" runat="server"
           AlternateText="Sort Descending"
           ImageUrl="images/pict2.jpg"
           OnCommand="ImageButton_Command"
           CommandName="Sort"
           CommandArgument="Descending"/>

      <br /><br />
    
      <asp:label id="Label1" runat="server"/>

   </form>

</body>
</html>

<!--</Snippet1>-->
