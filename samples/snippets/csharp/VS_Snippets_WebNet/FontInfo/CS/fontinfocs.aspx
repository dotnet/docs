<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void Page_Load(object sender, EventArgs e)
  {
    // When the page loads, set the the myLabel Label control's FontInfo properties.
    // Note that myLabel.Font is a FontInfo object.
    
    myLabel.Font.Bold = true;
    myLabel.Font.Italic = false;
    myLabel.Font.Name = "verdana";
    myLabel.Font.Overline = false;
    myLabel.Font.Size = 10;
    myLabel.Font.Strikeout = false;
    myLabel.Font.Underline = true;
    
    // Write information on the FontInfo object to the myLabel label.
    myLabel.Text = myLabel.Font.ToString();
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
