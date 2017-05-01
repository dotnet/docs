<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Function SiteSpecificAuthenticationMethod(ByVal UserName As String, ByVal Password As String) As Boolean
    ' Insert code that implements a site-specific custom 
    ' authentication method here.
    '
    ' This example implementation always returns false.
    Return False
End Function

Sub OnAuthenticate(ByVal sender As Object, ByVal e As AuthenticateEventArgs)
    Dim Authenticated As Boolean
    Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password)

    e.Authenticated = Authenticated
End Sub


</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server"
                OnAuthenticate="OnAuthenticate">
            </asp:Login>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
