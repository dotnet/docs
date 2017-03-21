 Public Sub FindDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     If Not mappings.Contains("Categories") Then
         Console.WriteLine("Error: no such table in collection")
     Else
         Console.WriteLine("Name: " & mappings("Categories").ToString() _
            & ControlChars.Cr + "Index: " _
            & mappings.IndexOf("Categories").ToString())
     End If
 End Sub