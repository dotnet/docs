 Public Sub CreateDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     Dim columns() As DataColumnMapping
     ' Copy mappings to array
     mappings.CopyTo(columns, 0)
     Dim mapping As New DataTableMapping _
        ("Categories", "DataCategories", columns)
 End Sub