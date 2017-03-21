 Public Sub FindDataColumnMapping()
     ' ...
     ' create mappings and mapping
     ' ...
     If mappings.IndexOfDataSetColumn("datadescription") <> - 1 Then
         mapping = mappings.GetByDataSetColumn("datadescription")
     End If
 End Sub