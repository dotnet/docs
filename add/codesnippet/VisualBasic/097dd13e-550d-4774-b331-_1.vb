      Dim enabledTablesList As String()
      enabledTablesList = SqlCacheDependencyAdmin.GetTablesEnabledForNotifications( _
        ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString)