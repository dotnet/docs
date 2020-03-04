<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void Page_Load(object sender, EventArgs e)
  {
    if (Page.Header != null)
    {
      // Create a Style object for the <body> section of the Web page.
      Style bodyStyle = new Style();

      bodyStyle.ForeColor = System.Drawing.Color.Blue;
      bodyStyle.BackColor = System.Drawing.Color.LightGray;

      // Add the style to the header of the current page.
      Page.Header.StyleSheet.CreateStyleRule(bodyStyle, this, "BODY");

      // Add text to the label2 control to see the style rules applied to it.
      label1.Text = "This is what the bodyStyle looks like.";
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <title>IStyleSheet Example</title>
</head>    
<body>
    <form id="form1" runat="server">
        <h1>IStyleSheet Example</h1>
        <asp:Label 
          id="label1" 
          runat="server">
        </asp:Label>
    </form>
  </body>
</html>
<!-- </snippet1> -->
