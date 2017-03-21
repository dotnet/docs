 Public Sub CreateDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     Dim columns1() As DataColumnMapping
     mappings.CopyTo(columns1, 0)
     Dim mapping As New DataTableMapping _
        ("Categories", "DataCategories", columns1)
        
     Dim columns2() As DataColumnMapping
     mapping.ColumnMappings.CopyTo(columns2, 0)
 End Sub