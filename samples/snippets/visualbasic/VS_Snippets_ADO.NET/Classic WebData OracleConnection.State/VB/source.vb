Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub createOracleConnection()
        Using connection As New OracleConnection()
            connection.ConnectionString = _
               "Data Source=Oracle8i;Integrated Security=yes"
            connection.Open()
            Console.WriteLine("Connection State: " & connection.State)
        End Using
    End Sub
    ' </Snippet1>
End Module
