<!--<Snippet1>-->
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EnabledButton_Click (object sender, ImageClickEventArgs e)
  {
    Label1.Text = "You selected the enabled button.";
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>ImageButton.Enabled Example</title>
</head>
<body>
  <form id="form1" runat="server">
    
    <h3>ImageButton.Enabled Example</h3>
    
    <asp:imagebutton id="EnabledImageButton"
      enabled="true"
      alternatetext="Enabled Button"
      imageurl="Images\EnabledButton.jpg"
      onclick="EnabledButton_Click"
      runat="Server">
    </asp:imagebutton>
    
    <br /><br /><br />    
    
    <asp:imagebutton id="NotEnabledImageButton"
      enabled="false"
      alternatetext="Not Enabled Button"
      imageurl="Images\NotEnabledButton.jpg"
      runat="Server">
    </asp:imagebutton> 
    
    <br /><br />
    
    <asp:label id="Label1"
      runat="Server">
    </asp:label>
 
  </form>
</body>
</html>
<!--</Snippet1>-->
