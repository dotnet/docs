<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>

<script runat="server">

Public Sub Page_Load()

  Snippet2()
  Snippet6()

End Sub

Public Sub Snippet2()

  '<Snippet2>
  Dim r As RolePrincipal

  If Roles.CacheRolesInCookie Then
    Dim roleCookie As String = ""

    Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies(Roles.CookieName)
    If Not cookie Is Nothing Then roleCookie = cookie.Value

    r = New RolePrincipal(User.Identity, roleCookie)
  Else
    r = new RolePrincipal(User.Identity)
  End If
  '</Snippet2>

  Response.Write(r.IsRoleListCached.ToString() + "<BR>")
End Sub


Public Sub Snippet6()

  '<Snippet6>
  Try
    Dim r As RolePrincipal = CType(User, RolePrincipal)
    Dim eTicket As String = r.ToEncryptedTicket()
    Dim cookie As HttpCookie = New HttpCookie(Roles.CookieName, eTicket)
    cookie.Path = Roles.CookiePath
    cookie.Expires = r.ExpireDate
    Response.Cookies.Add(cookie)
  Catch e As InvalidCastException
    Response.Write("User is not of type RolePrincipal. Are roles enabled?")
  End Try
  '</Snippet6>
End Sub

</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
