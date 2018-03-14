<!-- <Snippet2> -->
<%@ Page Language="C#" %>

<script runat="server">
  protected Exception ex = null;

  protected void Page_Load(object sender, EventArgs e)
  {
    // Get the last error from the server
    Exception ex = Server.GetLastError();

    // Create a safe message
    string safeMsg = "A problem has occurred in the web site. ";

    // Show Inner Exception fields for local access
    if (ex.InnerException != null)
    {
      innerTrace.Text = ex.InnerException.StackTrace;
      InnerErrorPanel.Visible = Request.IsLocal;
      innerMessage.Text = ex.InnerException.Message;
    }
    // Show Trace for local access
    if (Request.IsLocal)
      exTrace.Visible = true;
    else
      ex = new Exception(safeMsg, ex);

    // Fill the page fields
    exMessage.Text = ex.Message;
    exTrace.Text = ex.StackTrace;

    // Log the exception and notify system operators
    ExceptionUtility.LogException(ex, "Generic Error Page");
    ExceptionUtility.NotifySystemOps(ex);

    // Clear the error from the server
    Server.ClearError();
  }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
  <title>Generic Error Page</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <h2>
      Generic Error Page</h2>
    <asp:Panel ID="InnerErrorPanel" runat="server" Visible="false">
      <p>
        Inner Error Message:<br />
        <asp:Label ID="innerMessage" runat="server" Font-Bold="true" 
          Font-Size="Large" /><br />
      </p>
      <pre>
        <asp:Label ID="innerTrace" runat="server" />
      </pre>
    </asp:Panel>
    <p>
      Error Message:<br />
      <asp:Label ID="exMessage" runat="server" Font-Bold="true" 
        Font-Size="Large" />
    </p>
    <pre>
      <asp:Label ID="exTrace" runat="server" Visible="false" />
    </pre>
    <br />
    Return to the <a href='Default.aspx'> Default Page</a>
  </div>
  </form>
</body>
</html>
<!-- </Snippet2> -->
