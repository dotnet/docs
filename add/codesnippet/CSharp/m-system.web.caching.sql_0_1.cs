  protected void enableNotification_Click(object sender, EventArgs e)
  {
    SqlCacheDependencyAdmin.EnableNotifications(
      ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
  }