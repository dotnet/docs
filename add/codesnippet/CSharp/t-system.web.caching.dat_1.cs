    catch (DatabaseNotEnabledForNotificationException ex)
    {
      enabledTables.Visible = false;
      disableTable.Visible = false;
      enabledTablesMsg.Text = "Cache notifications are not enabled in this database.";

      tableName.Visible = false;
      enableTable.Visible = false;
      tableEnableMsg.Text = "Must enable database for notifications before enabling tables";
    }