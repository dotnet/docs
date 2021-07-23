Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public Class UpperCaseNamingPolicy
        Inherits JsonNamingPolicy

        Public Overrides Function ConvertName(name As String) As String
            Return name.ToUpper()
        End Function

    End Class

End Namespace
