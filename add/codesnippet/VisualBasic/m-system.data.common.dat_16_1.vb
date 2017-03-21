 Public Sub ChangedMyMind()
     ' ...
     ' create mappings and mapping
     ' ...
     If mappings.Contains(CType(mapping, Object)) Then
         mappings.Remove(CType(mapping, Object))
     Else
         mappings.Add(CType(mapping, Object))
         Console.WriteLine("Index of new mapping: " _
            + mappings.IndexOf(CType(mapping, Object)).ToString())
     End If
 End Sub