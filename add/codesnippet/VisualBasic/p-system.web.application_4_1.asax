    Sub AuthenticationService_Authenticating _
       (ByVal sender As Object, _
        ByVal e As System.Web.ApplicationServices.AuthenticatingEventArgs)
        
        If (e.Username.IndexOf("@contoso.com") >= 0) Then
            e.Authenticated = Membership.Providers("ContosoSqlProvider").ValidateUser(e.Username, e.Password)
        ElseIf (e.Username.IndexOf("@fabrikam.com") >= 0) Then
            e.Authenticated = Membership.Providers("FabrikamSqlProvider").ValidateUser(e.Username, e.Password)
        Else
            e.Authenticated = Membership.Provider.ValidateUser(e.Username, e.Password)
        End If
        e.AuthenticationIsComplete = True
    End Sub