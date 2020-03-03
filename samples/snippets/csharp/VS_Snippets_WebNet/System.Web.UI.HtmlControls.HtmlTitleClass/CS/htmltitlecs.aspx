<!-- <snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void Page_Load(object sender, EventArgs e)
  {

    if (Page.Header != null)
    {
      
      Page.Header.Title = "Welcome!  The time is: " + System.DateTime.Now;
      
    }
    
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head id="Head1" runat="server">
    <title>HtmlTitle Example</title>
</head>

  <body>

    <form id="form1" runat="server">

      <h3>HtmlTitle Example</h3>

    </form>

  </body>

</html>
<!-- </snippet1> -->