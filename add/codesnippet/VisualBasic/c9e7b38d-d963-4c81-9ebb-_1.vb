    Public Sub SaveSessionID(context As HttpContext, _
                             id As String, _
                             ByRef redirected As Boolean, _
                             ByRef cookieAdded As Boolean) _
      Implements ISessionIDManager.SaveSessionID
    
      redirected = False
      cookieAdded = False

      If pConfig.Cookieless = HttpCookieMode.UseUri Then

        ' Add the SessionID to the URI. Set the redirected variable as appropriate.

        redirected = True
        Return
      Else
        context.Response.Cookies.Add(New HttpCookie(pConfig.CookieName, id))
        cookieAdded = True
      End If
    End Sub