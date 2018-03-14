<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  // <Snippet1>
  protected void Page_Error(object sender, EventArgs e)
  {
    StringBuilder sb = new StringBuilder();
    sb.Append("URL that caused the error: <br/>");
    sb.Append(Server.HtmlEncode(Request.Url.ToString()));
    sb.Append("<br/><br/>");
    sb.Append("Error message: <br/>");
    sb.Append(Server.GetLastError().ToString());
    Response.Write(sb.ToString());
    Server.ClearError();
  }
  // </Snippet1>

  protected void ErrorButton_ButtonClick(object sender, EventArgs e)
  {
    // Create an error condition.
    String var = null;
    Response.Write(var.ToString());
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page_Error Handler</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      Click the button to cause an error to occur.
      <br />
      <asp:Button id="ErrorButton"
                  text="Submit"
                  runat="server" OnClick="ErrorButton_ButtonClick" />
      <br />
    </div>
    </form>
</body>
</html>
