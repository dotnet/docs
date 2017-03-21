    ' Defines a predicate deligate to use
    ' for the SortedSet.RemoveWhere method.
    Private Function isDoc(ByVal s As String) As Boolean
        If (s.ToLower.EndsWith(".txt") _
                    OrElse (s.ToLower.EndsWith(".doc") _
                    OrElse (s.ToLower.EndsWith(".xls") _
                    OrElse (s.ToLower.EndsWith(".xlsx") _
                    OrElse (s.ToLower.EndsWith(".pdf") _
                    OrElse (s.ToLower.EndsWith(".doc") _
                    OrElse s.ToLower.EndsWith(".docx"))))))) Then
            Return True
        Else
            Return False
        End If
    End Function