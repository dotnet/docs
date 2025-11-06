Imports System.Text.Json

Namespace ca2026

    Public Module Examples

        '<Violation>
        Public Sub ProcessJsonViolation(json As String)
            Dim element As JsonElement = JsonDocument.Parse(json).RootElement
            ' Process element
        End Sub
        '</Violation>

        '<Fixed>
        Public Sub ProcessJsonFixed(json As String)
            ' JsonElement.Parse is available in .NET 10+
#If NET10_0_OR_GREATER Then
            Dim element As JsonElement = JsonElement.Parse(json)
#Else
            ' This code demonstrates the preferred API for .NET 10+
            ' For compilation on earlier versions, we use the old pattern
            Dim element As JsonElement = JsonDocument.Parse(json).RootElement
#End If
            ' Process element
        End Sub
        '</Fixed>

    End Module

End Namespace
