 Public Sub AddDataColumnMapping()
     ' ...
     ' create columnMappings
     ' ...
     Dim mapping As New DataColumnMapping( _
        "Description", "DataDescription")
     columnMappings.Add(CType(mapping, Object))
     Console.WriteLine("Column {0} added to column mapping collection {1}.", _
        mapping.ToString(), columnMappings.ToString())
 End Sub