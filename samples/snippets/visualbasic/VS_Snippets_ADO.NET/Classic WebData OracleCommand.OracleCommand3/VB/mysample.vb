Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub CreateOracleCommand(ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            connection.Open()
            Dim transaction As OracleTransaction = connection.BeginTransaction()
            Dim queryString As String = _
               "SELECT * FROM Emp ORDER BY EmpNo"
            Dim command As New OracleCommand(queryString, connection, transaction)
            command.CommandType = CommandType.Text
        End Using
    End Sub
    ' </Snippet1>
End Module
