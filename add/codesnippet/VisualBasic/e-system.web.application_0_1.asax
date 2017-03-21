    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.AuthenticationService.Authenticating, _
          AddressOf Me.AuthenticationService_Authenticating
    End Sub