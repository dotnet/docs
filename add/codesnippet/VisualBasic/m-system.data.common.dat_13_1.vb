 Public Sub FindDataTableMapping()
     ' ...
     ' create mappings and mapping
     ' ...
     If mappings.IndexOfDataSetTable("datacategories") <> - 1 Then
         mapping = mappings.GetByDataSetTable("datacategories")
     End If
 End Sub