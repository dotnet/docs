<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    // Create two instances of an HtmlMeta control.
    HtmlMeta hm1 = new HtmlMeta();
    HtmlMeta hm2 = new HtmlMeta();    

    // Get a reference to the page header element.
    HtmlHead head = (HtmlHead)Page.Header;
    
    // Define an HTML <meta> element that is useful for search engines.
    hm1.Name = "keywords";
    hm1.Content = "words that describe your web page";
    head.Controls.Add(hm1);
    
    // Define an HTML <meta> element with a Scheme attribute.
    hm2.Name = "date";
    hm2.Content = DateTime.Now.ToString("yyyy-MM-dd");
    hm2.Scheme = "YYYY-MM-DD";
    head.Controls.Add(hm2);
    
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HtmlMeta Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    View the HTML source code of the page to see the two HTML meta elements added.
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
