   Public Shared Function StripComments(lines() As String) As String()
      Dim lineList As New List(Of String)
      For Each line As String In lines
         If line.TrimStart(" "c).StartsWith("'") Then
            linelist.Add(line.TrimStart("'"c, " "c))
         End If
      Next
      Return lineList.ToArray()
   End Function   