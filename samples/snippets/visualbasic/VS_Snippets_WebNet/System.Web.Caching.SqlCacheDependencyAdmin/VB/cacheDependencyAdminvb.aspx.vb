' <Snippet1>
Partial Class cacheDependencyAdminvb
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    'Put the page into a default state.
    enabledTables.Visible = True
    disableTable.Visible = True
    enabledTablesMsg.Text = "Tables enabled for change notification:"

    tableName.Visible = True
    enableTable.Visible = True
    tableEnableMsg.Text = "Enable change notification on table(s):"
    enableTableErrorMsg.Text = ""
  End Sub

  Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
    Try
      ' <Snippet2>
      Dim enabledTablesList As String()
      enabledTablesList = SqlCacheDependencyAdmin.GetTablesEnabledForNotifications( _
        ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString)
      ' </Snippet2>
      If enabledTablesList.Length > 0 Then
        enabledTables.DataSource = enabledTablesList
        enabledTables.DataBind()
      Else
        enabledTablesMsg.Text = "No tables are enabled for change notifications."
        enabledTables.Visible = False
        disableTable.Visible = False
      End If
    ' <Snippet8>
    Catch ex As DatabaseNotEnabledForNotificationException
      enabledTables.Visible = False
      disableTable.Visible = False
      enabledTablesMsg.Text = "Cache notifications are not enabled in this database."

      tableName.Visible = False
      enableTable.Visible = False
      tableEnableMsg.Text = "Must enable database for notifications before enabling tables."
    End Try
    ' </Snippet8>
  End Sub
  ' <Snippet3>
  Protected Sub enableNotification_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    SqlCacheDependencyAdmin.EnableNotifications( _
        ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString)
  End Sub
  ' </Snippet3>
  ' <Snippet4>
  Protected Sub disableNotification_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    SqlCacheDependencyAdmin.DisableNotifications( _
        ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString)
  End Sub
  ' </Snippet4>
  ' <Snippet5>
  Protected Sub disableTable_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    For Each item As ListItem In enabledTables.Items
      If item.Selected Then
        SqlCacheDependencyAdmin.DisableTableForNotifications( _
        ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString, _
        item.Text)
      End If
    Next
  End Sub
  ' </Snippet5>
  Protected Sub enableTable_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Try
      If tableName.Text.Contains(";") Then
        ' <Snippet6>
        Dim tables As String()
        tables = tableName.Text.Split(New [Char]() {";"c})
        For i As Integer = 0 To tables.Length - 1
          tables(i) = tables(i).Trim
        Next

        SqlCacheDependencyAdmin.EnableTableForNotifications( _
          ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString, _
          tables)
        ' </Snippet6>
      Else
        ' <Snippet7>
        SqlCacheDependencyAdmin.EnableTableForNotifications( _
          ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString, _
          tableName.Text)
        ' </Snippet7>
      End If
    Catch ex As HttpException
      enableTableErrorMsg.Text = "<br />" & _
        "An error occured enabling a table.<br />" & _
        "The error message was: " & _
        ex.Message
      enableTableErrorMsg.Visible = True
    End Try
  End Sub

End Class
' </Snippet1>