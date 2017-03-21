 Public Sub FindDataTableMapping()
     ' ...
     ' create mappings and mapping
     ' ...
     If mappings.Contains("Categories") Then
         mapping = _
            DataTableMappingCollection.GetTableMappingBySchemaAction _
            (mappings, "Categories", "", MissingMappingAction.Ignore)
     End If
 End Sub