 Public Sub AddDataTableMapping()
     ' ...
     ' create tableMappings
     ' ...
     Dim mapping As New DataTableMapping( _
        "Categories", "DataCategories")
     tableMappings.Add(CType(mapping, Object))
     Console.WriteLine( _
        "Table {0} added to {1} table mapping collection.", _
        mapping.ToString(), tableMappings.ToString())
 End Sub