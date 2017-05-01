<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ImageButton Sample</title>
<script language="VB" runat="server">

      Sub ImageButton_Click(sender As Object, e As ImageClickEventArgs) 
         Label1.Text = "You clicked the ImageButton control at the coordinates: (" & _ 
                       e.X.ToString() & ", " & e.Y.ToString() & ")"
      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>ImageButton Sample</h3>

      Click anywhere on the image.<br /><br />

      <asp:ImageButton id="imagebutton1" runat="server"
           AlternateText="ImageButton 1"
           ImageAlign="left"
           ImageUrl="images/pict.jpg"
           OnClick="ImageButton_Click"/>

      <br /><br />
    
      <asp:label id="Label1" runat="server"/>

   </form>

</body>
</html>

<!--</Snippet1>-->
