Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub CreateOracleCommand(ByVal myExecuteQuery As String, _
    ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(myExecuteQuery, connection)
            command.Connection.Open()
            command.ExecuteNonQuery()
        End Using
    End Sub
    ' </Snippet1>
End Module
