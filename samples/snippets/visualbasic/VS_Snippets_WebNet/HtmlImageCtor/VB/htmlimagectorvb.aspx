<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create an HtmlImage control.
         Dim image As HtmlImage = New HtmlImage()
         image.Src = "image.jpg"
         image.Alt = "Alternate text for image." 
 
         ' Add the control to the Controls collection of the 
         ' PlaceHolder control.
         Place.Controls.Clear()
         Place.Controls.Add(image)
         
      End Sub
  
   </script>
  
<head runat="server">
    <title> HtmlImage Constructor Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlImage Constructor Example </h3> 
  
      <asp:PlaceHolder id="Place" runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
