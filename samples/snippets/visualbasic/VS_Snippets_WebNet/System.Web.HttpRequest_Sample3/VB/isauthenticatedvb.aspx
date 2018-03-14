<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

' <snippet1>
    Private Sub Page_Load(sender As Object, e As EventArgs)
        ' Check whether the current request has been
        ' authenticated. If it has not, redirect the 
        ' user to the Login.aspx page.
        If (Request.IsAuthenticated = False) Then
            Response.Redirect("Login.aspx")
        End If
    End Sub
' </snippet1>

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
