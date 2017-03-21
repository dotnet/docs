    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler System.Web.ApplicationServices.ProfileService.ValidatingProperties, _
          AddressOf ProfileService_ValidatingProperties
    End Sub
    
    Sub ProfileService_ValidatingProperties(ByVal sender As Object, ByVal e As System.Web.ApplicationServices.ValidatingPropertiesEventArgs)
        If (String.IsNullOrEmpty(CType(e.Properties("FirstName"), String))) Then
            e.FailedProperties.Add("FirstName")
        End If
    End Sub