<!--<Snippet1>-->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Image Example</title>
<script language="C#" runat="server">

      void Page_Load(Object sender, EventArgs e)
      {
         Image myImage = new Image();
         myImage.AlternateText = "Image Text";
         myImage.ImageUrl = "image1.jpg";
         myImage.ImageAlign = ImageAlign.Left;
         Page.Controls.Add(myImage);

      }

   </script>

</head>
 
<body>

   <form id="form1" runat="server">

      <h3>Image Example</h3>
  
   </form>

</body>
</html>
   
<!--</Snippet1>-->
