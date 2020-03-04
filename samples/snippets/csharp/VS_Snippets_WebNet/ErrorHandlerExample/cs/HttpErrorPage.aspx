<!-- <Snippet4> -->
<%@ Page Language="C#" %>

<script runat="server">
  protected HttpException ex = null;

  protected void Page_Load(object sender, EventArgs e)
  {
    ex = (HttpException)Server.GetLastError();
    int httpCode = ex.GetHttpCode();

    // Filter for Error Codes and set text
    if (httpCode >= 400 && httpCode < 500)
      ex = new HttpException
          (httpCode, "Safe message for 4xx HTTP codes.", ex);
    else if (httpCode > 499)
      ex = new HttpException
          (ex.ErrorCode, "Safe message for 5xx HTTP codes.", ex);
    else
      ex = new HttpException
          (httpCode, "Safe message for unexpected HTTP codes.", ex);

    // Log the exception and notify system operators
    ExceptionUtility.LogException(ex, "HttpErrorPage");
    ExceptionUtility.NotifySystemOps(ex);

    // Fill the page fields
    exMessage.Text = ex.Message;
    exTrace.Text = ex.StackTrace;

    // Show Inner Exception fields for local access
    if (ex.InnerException != null)
    {
      innerTrace.Text = ex.InnerException.StackTrace;
      InnerErrorPanel.Visible = Request.IsLocal;
      innerMessage.Text = string.Format("HTTP {0}: {1}",
        httpCode, ex.InnerException.Message);
    }
    // Show Trace for local access
    exTrace.Visible = Request.IsLocal;

    // Clear the error from the server
    Server.ClearError();
  }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
  <title>Http Error Page</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <h2>
      Http Error Page</h2>
    <asp:Panel ID="InnerErrorPanel" runat="server" Visible="false">
      <asp:Label ID="innerMessage" runat="server" Font-Bold="true" 
        Font-Size="Large" /><br />
      <pre>
        <asp:Label ID="innerTrace" runat="server" />
      </pre>
    </asp:Panel>
    Error Message:<br />
    <asp:Label ID="exMessage" runat="server" Font-Bold="true" 
      Font-Size="Large" />
    <pre>
      <asp:Label ID="exTrace" runat="server" Visible="false" />
    </pre>
    <br />
    Return to the <a href='Default.aspx'>Default Page</a>
  </div>
  </form>
</body>
</html>
<!-- </Snippet4> -->
