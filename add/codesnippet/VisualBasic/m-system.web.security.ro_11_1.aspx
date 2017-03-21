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