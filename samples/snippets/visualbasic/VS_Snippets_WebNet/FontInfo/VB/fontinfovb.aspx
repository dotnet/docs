<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
  
    ' When the page loads, set the the myLabel Label control's FontInfo properties.
    ' Note that myLabel.Font is a FontInfo object.
    
    myLabel.Font.Bold = True
    myLabel.Font.Italic = False
    myLabel.Font.Name = "verdana"
    myLabel.Font.Overline = False
    myLabel.Font.Size = 10
    myLabel.Font.Strikeout = False
    myLabel.Font.Underline = True
    
    ' Write information on the FontInfo object to the myLabel label.
    myLabel.Text = myLabel.Font.ToString()
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FontInfo Example</title>
</head>
  <body>
    <form id="form1" runat="server">
    <h3>FontInfo Example</h3>
      <asp:Label id="myLabel" 
        runat="server" >
      </asp:Label>
    </form>
  </body>
</html>
<!-- </snippet1> -->
