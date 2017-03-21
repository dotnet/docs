    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.RoleService.SelectingProvider, _
            AddressOf Me.RoleService_SelectingProvider
    End Sub
    
    Sub RoleService_SelectingProvider _
    (ByVal sender As Object, _
     ByVal e As System.Web.ApplicationServices.SelectingProviderEventArgs)

        If (e.User.Identity.Name.IndexOf("@example.com") > 0) Then
            e.ProviderName = "EmployeeRoleProvider"
        Else
            e.ProviderName = "CustomerRoleProvider"
        End If
    End Sub