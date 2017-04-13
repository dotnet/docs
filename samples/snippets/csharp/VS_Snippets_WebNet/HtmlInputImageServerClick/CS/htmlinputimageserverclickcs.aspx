<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
      
  void ImageBtn_Click(Object sender, ImageClickEventArgs e)
  {

    // Display the coordinates of the position where the image 
    // was clicked. 
    Span1.InnerText = "You clicked at (" + e.X.ToString() +
                      ", " + e.Y.ToString() + ").";

  }

  void Page_Load(Object sender, EventArgs e)
  {

    // Create an EventHandler delegate for the method you want to 
    // handle the event, and then add it to the list of methods called
    // when the event is raised.
    Image1.ServerClick += new ImageClickEventHandler(this.ImageBtn_Click);

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HtmlInputImage ServerClick Example </title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlInputImage ServerClick Example </h3>

      <input type="image"
             id="Image1"
             src="Image.jpg" 
             alt="Image"
             runat="server"/>

      <br />

      <span id="Span1" 
            runat="server"/>

   </form>

</body>
</html>
<!-- </Snippet1> -->   