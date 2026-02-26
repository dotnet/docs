Imports System.Text.Json

Namespace ca2026

    Public Module Examples

        '<Violation>
        Public Sub ProcessJsonViolation(json As String)
            Dim element As JsonElement = JsonDocument.Parse(json).RootElement
            '...
        End Sub
        '</Violation>

        '<Fixed>
        Public Sub ProcessJsonFixed(json As String)
            Dim element As JsonElement = JsonElement.Parse(json)
            '...
        End Sub
        '</Fixed>

    End Module

End Namespace
