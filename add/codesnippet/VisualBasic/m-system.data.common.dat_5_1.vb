 Public Sub RemoveDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     If mappings.Contains("Categories") Then
         mappings.RemoveAt("Categories")
     End If
 End Sub