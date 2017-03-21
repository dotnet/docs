 Public Function PushIntoArray() As Boolean
     ' ...
     ' create mappings
     ' ...
     Dim columns As DataColumnMapping()
     mappings.CopyTo(columns, 0)
     mappings.Clear()
     PushIntoArray = True
 End Function