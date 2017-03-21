 Public Sub AddDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     Dim mapping As New DataTableMapping("Categories", "DataCategories")
     mappings.Add(CType(mapping, Object))
     Console.WriteLine("Table " & mapping.ToString() & " added to " _
        & "table mapping collection " & mappings.ToString())
 End Sub