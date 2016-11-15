        Dim i As Integer
        For i = 1 To 10
            Debug.WriteLine(i)
            ' Stop during each iteration and wait for user to resume.
            Stop
        Next i