<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void Page_Load (object sender, System.EventArgs e)
  {
    string text;
    
    // Get the value of TextBox1 from the page that 
    // posted to this page.
    text = ((TextBox)PreviousPage.FindControl("TextBox1")).Text;
    
    // Check for an empty string.
    if (text != "")
      PostedLabel.Text = "The string posted from the previous page is "
                         + text + ".";
    else
      PostedLabel.Text = "An empty string was posted from the previous page.";
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>ImageButton.PostBackUrl Target Page Example</title>
</head>
<body>
  <form id="form1" runat="server">
    
    <h3>ImageButton.PostBackUrl Target Page Example</h3>
      
    <br />
    
    <asp:label id="PostedLabel"
       runat="Server">
    </asp:label>

    </form>
</body>
</html>
<!--</Snippet1>-->
