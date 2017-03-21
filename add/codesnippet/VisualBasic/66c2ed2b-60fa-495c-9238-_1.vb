 Public Sub FindDataColumnMapping()
     ' ...
     ' create mappings and mapping
     ' ...
     If mappings.Contains("Description") Then
         mapping = _
            DataColumnMappingCollection.GetColumnMappingBySchemaAction _
            (mappings, "Description", MissingMappingAction.Ignore)
     End If
 End Sub