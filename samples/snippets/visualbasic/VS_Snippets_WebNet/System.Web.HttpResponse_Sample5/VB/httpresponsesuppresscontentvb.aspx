<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Private Sub Page_Load(sender As Object, e As EventArgs)

    ' <snippet3>
        ' Check whether the request is sent
        ' over HTTPS. If not, do not return
        ' content to the client.
        If (Request.IsSecureConnection = False) Then      
            Response.SuppressContent = True
        End If
    ' </snippet3>
    End Sub


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Insert content here -->
    </form>
</body>
</html>
