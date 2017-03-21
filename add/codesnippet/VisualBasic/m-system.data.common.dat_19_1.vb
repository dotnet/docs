 Public Sub PushIntoArray()
     ' ...
     ' create DataTableMappingCollection collection mappings
     ' ...
     Dim tables() As DataTableMapping
     mappings.CopyTo(tables, 0)
     mappings.Clear()
 End Sub