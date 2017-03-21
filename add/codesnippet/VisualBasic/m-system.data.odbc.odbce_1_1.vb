    Public Sub DisplayOdbcErrors(ByVal exception As OdbcException)
        Dim i As Integer

        For i = 0 To exception.Errors.Count - 1
            Console.WriteLine("Index #" & i.ToString() & ControlChars.Cr _
               & "Error: " & exception.Errors(i).ToString() & ControlChars.Cr)
        Next i
        Console.ReadLine()
    End Sub