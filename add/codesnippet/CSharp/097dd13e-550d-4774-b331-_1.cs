      string[] enabledTablesList =
      SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(
        ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);