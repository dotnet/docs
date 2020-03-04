<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
      
  Sub ImageBtn_Click(ByVal Sender As Object, ByVal E As ImageClickEventArgs)

    ' Write the click coordinates to the Span1 element.
    Span1.InnerText = "You clicked at (" & E.X.ToString() & _
                      ", " & E.Y.ToString() & ")."
      
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" > 
<head runat="server">
    <title>Click the Image </title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>Click the Image </h3>

      <input type="image"
             alt="Image Alternate Text"
             src="Image1.jpg" 
             onserverclick="ImageBtn_Click"
             runat="server"/>

      <br />
      <br />

      <span id="Span1" 
            runat="server"/>

   </form>

</body>
</html>
   
<!--</Snippet1>-->
