<!-- <Snippet4> -->
<%@ Page Language="VB" %>

<script runat="server">
  Dim ex As HttpException = Nothing
    
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    ex = CType(Server.GetLastError, HttpException)
    Dim httpCode As Integer = ex.GetHttpCode

    ' Filter for Error Codes and set text
    If ((httpCode >= 400) AndAlso (httpCode < 500)) Then
      ex = New HttpException(httpCode, _
        "Safe message for 4xx HTTP codes.", ex)
    ElseIf (httpCode > 499) Then
      ex = New HttpException(ex.ErrorCode, _
        "Safe message for 5xx HTTP codes.", ex)
    Else
      ex = New HttpException(httpCode, _
        "Safe message for unexpected HTTP codes.", ex)
    End If

    ' Log the exception and notify system operators
    ExceptionUtility.LogException(ex, "HttpErrorPage")
    ExceptionUtility.NotifySystemOps(ex)

    ' Fill the page fields
    exMessage.Text = ex.Message
    exTrace.Text = ex.StackTrace

    ' Show Inner Exception fields for local access
    If ex.InnerException IsNot Nothing Then
      innerTrace.Text = ex.InnerException.StackTrace
      InnerErrorPanel.Visible = Request.IsLocal
      innerMessage.Text = _
        "HTTP " & httpCode & ": " & ex.InnerException.Message
    End If

    ' Show Trace for local access
    exTrace.Visible = Request.IsLocal
    ' Clear the error from the server
    Server.ClearError()
  End Sub

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
