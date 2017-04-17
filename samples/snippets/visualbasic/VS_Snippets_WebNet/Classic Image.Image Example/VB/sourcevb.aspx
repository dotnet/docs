<!--<Snippet1>-->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Image Example</title>
<script language="VB" runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)
         Dim myImage As New Image()
         myImage.AlternateText = "Image Text"
         myImage.ImageUrl = "image1.jpg"
         myImage.ImageAlign = ImageAlign.Left
         Page.Controls.Add(myImage)
      End Sub

   </script>

</head>
 
<body>

   <form id="form1" runat="server">

      <h3>Image Example</h3>
  
   </form>

</body>
</html>
   
<!--</Snippet1>-->
