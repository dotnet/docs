        Dim count As Integer = 0
        Dim message As String

        If count = 0 Then
            message = "There are no items."
        ElseIf count = 1 Then
            message = "There is 1 item."
        Else
            message = "There are " & count & " items."
        End If
