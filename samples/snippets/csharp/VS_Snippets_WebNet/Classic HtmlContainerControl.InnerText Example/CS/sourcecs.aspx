<!--<Snippet1>-->
<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(Object Src, EventArgs E)
  {
    Message.InnerText = "To make text bold, use the <b> tag.";
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HtmlContainerControl Example</title>
</head>
  <body>
    <form id="form1" runat="server">
    <div>
    <b><span id="Message" runat="server"></span></b>
    </div>
    </form>
  </body>
</html>    
<!--</Snippet1>-->
