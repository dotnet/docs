   ' Return a strongly typed view for the current data source control.
   Private view As CsvDataSourceView = Nothing

   Protected Overrides Function GetView(viewName As String) As DataSourceView
      If view Is Nothing Then
         view = New CsvDataSourceView(Me, String.Empty)
      End If
      Return view
   End Function 'GetView