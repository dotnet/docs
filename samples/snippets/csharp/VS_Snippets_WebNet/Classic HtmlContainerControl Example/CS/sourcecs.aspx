<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    Message.InnerHtml = Server.HtmlEncode("Welcome! You accessed this page at: " + DateTime.Now);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HtmlContainerControl Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <span id="Message" runat="server"></span>    
    </div>
    </form>
</body>
</html>    
<!--</Snippet1>-->
