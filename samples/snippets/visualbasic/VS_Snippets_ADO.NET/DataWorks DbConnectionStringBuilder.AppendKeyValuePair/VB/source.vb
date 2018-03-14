Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Text

Module Module1

    Sub Main()
    End Sub
    ' <Snippet1>
    Public Function AddPooling(ByVal connectionString As String) As String
        Dim builder As New StringBuilder(connectionString)
        DbConnectionStringBuilder.AppendKeyValuePair(builder, "Pooling", "True")
        Return builder.ToString()
    End Function
    ' </Snippet1>

End Module
