   ' The ListSourceHelper class calls GetList, which
   ' calls the DataSourceControl.GetViewNames method.
   ' Override the original implementation to return
   ' a collection of one element, the default view name.
   Protected Overrides Function GetViewNames() As ICollection
      Dim al As New ArrayList(1)
      al.Add(CsvDataSourceView.DefaultViewName)
      Return CType(al, ICollection)
   End Function 'GetViewNames

End Class 'CsvDataSource