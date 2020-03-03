<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
      
  Sub ImageBtn_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)

    ' Display the coordinates of the position where the image 
    ' was clicked.
    Span1.InnerText = "You clicked at (" & e.X.ToString() & _
                      ", " & e.Y.ToString() & ")."
      
  End Sub
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
      
    ' Create an EventHandler delegate for the method you want to 
    ' handle the event, and then add it to the list of methods called
    ' when the event is raised.
    AddHandler Image1.ServerClick, AddressOf ImageBtn_Click

  End Sub

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