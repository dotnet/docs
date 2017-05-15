<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    Message.InnerHtml = Server.HtmlEncode("Welcome! You accessed this page at: " & DateTime.Now)

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
