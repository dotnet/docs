<%@ Page Language="C#" %>
<html>
<head>

   <script language="C#" runat="server">
      // <snippet1>
      // Define the event handler that uses coordinate information through ImageClickEventArgs.
      void ImageButton_Click(object sender, ImageClickEventArgs e) 
      {
         Label1.Text = "You clicked the ImageButton control at the coordinates: (" + 
                       e.X.ToString() + ", " + e.Y.ToString() + ")";
      }
      // </snippet1>
   </script>

</head>

<body>

   <form runat="server">

      <h3>ImageButton Sample</h3>

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