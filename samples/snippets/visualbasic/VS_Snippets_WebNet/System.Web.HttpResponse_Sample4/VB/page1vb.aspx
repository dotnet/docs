<%--<snippet1>--%>
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Private Sub Page_Load(sender As Object, e As EventArgs)

        ' Check whether the browser remains
        ' connected to the server.
        If (Response.IsClientConnected) Then

            ' If still connected, redirect
            ' to another page.             
            Response.Redirect("Page2VB.aspx", false)
        Else
            ' If the browser is not connected
            ' stop all response processing.
            Response.End()
        End If
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
<%--</snippet1>--%>
