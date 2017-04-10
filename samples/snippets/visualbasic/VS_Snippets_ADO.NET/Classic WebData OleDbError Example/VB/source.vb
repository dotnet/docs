Imports System.Data.OleDb

Module Module1

    Sub Main()
        'DisplayOleDbErrorCollection()
    End Sub

    ' <Snippet1>
    Public Sub DisplayOleDbErrorCollection(ByVal exception As OleDbException)
        Dim i As Integer

        For i = 0 To exception.Errors.Count - 1
            Console.WriteLine("Index #" & i.ToString() & ControlChars.Cr _
               & "Message: " & exception.Errors(i).Message & ControlChars.Cr _
               & "Native: " & exception.Errors(i).NativeError.ToString() & ControlChars.Cr _
               & "Source: " & exception.Errors(i).Source & ControlChars.Cr _
               & "SQL: " & exception.Errors(i).SQLState & ControlChars.Cr)
        Next i
        Console.ReadLine()
    End Sub
    ' </Snippet1>
End Module
