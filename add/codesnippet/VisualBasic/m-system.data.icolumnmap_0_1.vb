 Public Sub RemoveDataColumnMapping()
     ' ...
     ' create columnMappings
     ' ...
     If columnMappings.Contains("Picture") Then
         columnMappings.RemoveAt("Picture")
     End If
 End Sub