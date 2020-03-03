<!-- <snippet1> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Page_Init(object sender, EventArgs e)
  {
    // <snippet2>
    // Define an HtmlLink control.
    HtmlLink myHtmlLink = new HtmlLink();
    myHtmlLink.Href = "~/StyleSheet.css";
    myHtmlLink.Attributes.Add("rel", "stylesheet");
    myHtmlLink.Attributes.Add("type", "text/css");
    // </snippet2>
    
    // Add the HtmlLink to the Head section of the page.
    Page.Header.Controls.Add(myHtmlLink);
    
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="head1" 
        runat="server">
    <title>HtmlLink Example Page</title>
  </head>
  <body>
    <form id="form1" 
          runat="server">
      <h1>HtmlLink Example Page</h1>
      This is some text in the body of the Web Forms page.
    </form>
  </body>
</html>
<!-- </snippet1> -->
