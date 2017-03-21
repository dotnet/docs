    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.AuthenticationService.CreatingCookie, _
            AddressOf Me.AuthenticationService_CreatingCookie
    End Sub