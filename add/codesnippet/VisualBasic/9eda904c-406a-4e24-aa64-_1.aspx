  Dim r As RolePrincipal

  If Roles.CacheRolesInCookie Then
    Dim roleCookie As String = ""

    Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies(Roles.CookieName)
    If Not cookie Is Nothing Then roleCookie = cookie.Value

    r = New RolePrincipal(User.Identity, roleCookie)
  Else
    r = new RolePrincipal(User.Identity)
  End If