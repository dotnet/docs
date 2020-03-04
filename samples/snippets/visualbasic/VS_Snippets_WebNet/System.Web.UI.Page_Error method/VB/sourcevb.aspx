<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ' <Snippet1>
  Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs)
    
    Dim sb As New StringBuilder()
    sb.Append("URL that caused the error: <br/>")
    sb.Append(Server.HtmlEncode(Request.Url.ToString()))
    sb.Append("<br/><br/>")
    sb.Append("Error message: <br/>")
    sb.Append(Server.GetLastError().ToString())
    Response.Write(sb.ToString())
    Server.ClearError()    

  End Sub
  ' </Snippet1>
  
  Protected Sub ErrorButton_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Create an error condition.
    Dim var As String
    Response.Write(var.ToString())
    
  End Sub
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
      <asp:Label id="MessageLabel"
                 runat="server">
      </asp:Label>
    </div>
    </form>
</body>
</html>
