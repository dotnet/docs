Imports System.Buffers

Namespace ExampleCode
    Partial Friend Class DemoCode

        Private Shared ReadOnly Commands As SearchValues(Of String) =
            SearchValues.Create(
                {"start", "run", "go", "begin", "commence"},
                StringComparison.OrdinalIgnoreCase)

        Sub ProcessCommand(command As String)
            If Commands.Contains(command) Then
                ' ...
            End If
        End Sub

    End Class
End Namespace
