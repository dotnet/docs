<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">  
  
  protected void Page_Load(object sender, System.EventArgs e)
  {
      
      // Create a Style object for the body of the page.
      Style bodyStyle = new Style();

      bodyStyle.ForeColor = System.Drawing.Color.Blue;
      bodyStyle.BackColor = System.Drawing.Color.LightGray;

      // <Snippet2>
      // Add the style rule named bodyStyle to the header 
      // of the current page. The rule is for the body HTML element.
      Page.Header.StyleSheet.CreateStyleRule(bodyStyle, null, "body");
      // </Snippet2>
 
      // Add the page title to the header element.
      Page.Header.Title = "HtmlHead Example"; 
                   
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="head1"
      runat="server">
      <title>To be replaced.</title>
</head>

<body>
  <form id="form1" runat="server">
  
  <h3>HtmlHead Class Example</h3>  
    
  <asp:label id="Label1" 
    text = "View the HTML source code of this page to see the title 
            and body style added to the header element."
    runat="server">
  </asp:label>   
    
  </form>
</body>
</html>
<!--</Snippet1>-->