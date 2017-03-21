 Public Sub CreateDataTable()
     ' ...
     ' create dataSet and mapping
     ' ...
     Dim table As DataTable = mapping.GetDataTableBySchemaAction _
        (dataSet, MissingSchemaAction.Ignore)
 End Sub