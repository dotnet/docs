Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub CreateOracleCommand _
    (ByVal queryString As String, ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString, connection)
            command.Connection.Open()
            command.ExecuteReader()
            command.Cancel()
        End Using
    End Sub
    ' </Snippet1>
End Module
