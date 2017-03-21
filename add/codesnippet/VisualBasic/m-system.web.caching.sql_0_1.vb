  Protected Sub enableNotification_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    SqlCacheDependencyAdmin.EnableNotifications( _
        ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString)
  End Sub