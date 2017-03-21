    Catch ex As DatabaseNotEnabledForNotificationException
      enabledTables.Visible = False
      disableTable.Visible = False
      enabledTablesMsg.Text = "Cache notifications are not enabled in this database."

      tableName.Visible = False
      enableTable.Visible = False
      tableEnableMsg.Text = "Must enable database for notifications before enabling tables."
    End Try