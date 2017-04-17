<!-- <Snippet1> -->
<%@ Page Language="VB" Trace="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
  
    Try
      If (IsPostBack) Then
        
        Select Case Request.Form("__EVENTTARGET")
          Case "WarnLink"
            Throw New ArgumentException("Trace warn.")
          Case "WriteLink"
            Throw New InvalidOperationException("Trace write.")
          Case Else
            Throw New ArgumentException("General exception.")
        End Select  
      End If
    Catch ae As ArgumentException
      Trace.Warn("Exception Handling", "Warning: Page_Load.", ae)
    Catch ioe As InvalidOperationException
      Trace.Write("Exception Handling", "Exception: Page_Load.", ioe)
    End Try
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Trace Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:LinkButton id="WriteLink" 
                      runat="server"
                      text="Generate Trace Write" />
      <asp:LinkButton id="WarnLink"
                      runat="server"
                      text="Generate Trace Warn" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
