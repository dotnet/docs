Imports System.Data.SqlClient

Module Module1

    Sub Main()
        'DisplaySqlErrors()
    End Sub

    ' <Snippet1>
    Public Sub DisplaySqlErrors(ByVal exception As SqlException)
        Dim i As Integer

        For i = 0 To exception.Errors.Count - 1
            Console.WriteLine(("Index #" & i & ControlChars.NewLine & _
                "Source: " & exception.Errors(i).Source & ControlChars.NewLine & _
                "Number: " & exception.Errors(i).Number.ToString() & ControlChars.NewLine & _
                "State: " & exception.Errors(i).State.ToString() & ControlChars.NewLine & _
                "Class: " & exception.Errors(i).Class.ToString() & ControlChars.NewLine & _
                "Server: " & exception.Errors(i).Server & ControlChars.NewLine & _
                "Message: " & exception.Errors(i).Message & ControlChars.NewLine & _
                "Procedure: " & exception.Errors(i).Procedure & ControlChars.NewLine & _
                "LineNumber: " & exception.Errors(i).LineNumber.ToString()))
        Next i
        Console.ReadLine()
    End Sub
    ' </Snippet1>

End Module

