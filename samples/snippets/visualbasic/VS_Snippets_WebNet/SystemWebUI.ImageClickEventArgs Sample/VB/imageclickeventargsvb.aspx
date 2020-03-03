<%@ Page Language="VB" %>
<html>
<head>

   <script language="VB" runat="server">
      ' <snippet1>
      ' Define the event handler that uses coordinate information through ImageClickEventArgs.
      Sub ImageButton_Click(sender As Object, e As ImageClickEventArgs) 
         Label1.Text = "You clicked the ImageButton control at the coordinates: (" & _ 
                       e.X.ToString() & ", " & e.Y.ToString() & ")"
      End Sub
      '</snippet1>
   </script>

</head>

<body>

   <form runat="server">

      <h3>Using ImageClickEventArgs</h3>

      Click anywhere on the image.<br><br>

      <asp:ImageButton id="imagebutton1" runat="server"
           AlternateText="ImageButton 1"
           ImageAlign="left"
           ImageUrl="images\pict.jpg"
           OnClick="ImageButton_Click"/>

      <br><br>
    
      <asp:label id="Label1" runat="server"/>

   </form>

</body>
</html>