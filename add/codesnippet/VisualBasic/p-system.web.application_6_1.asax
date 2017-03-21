    Sub AuthenticationService_CreatingCookie(ByVal sender As Object, _
                     ByVal e As System.Web.ApplicationServices.CreatingCookieEventArgs)
        Dim ticket As FormsAuthenticationTicket = New _
           FormsAuthenticationTicket _
            (1, _
             e.Username, _
             DateTime.Now, _
             DateTime.Now.AddMinutes(30), _
             e.IsPersistent, _
             e.CustomCredential, _
             FormsAuthentication.FormsCookiePath)
            
        Dim encryptedTicket As String = FormsAuthentication.Encrypt(ticket)
        
        Dim cookie As HttpCookie = New _
            HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
        cookie.Expires = DateTime.Now.AddMinutes(30)
        
        HttpContext.Current.Response.Cookies.Add(cookie)
        e.CookieIsSet = True
    End Sub