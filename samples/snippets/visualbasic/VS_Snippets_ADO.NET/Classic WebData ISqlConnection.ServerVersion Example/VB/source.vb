Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim connectionString As String = _
           "Persist Security Info=False;Integrated Security=SSPI;database=Northwind;server=(local)"
        CreateSqlConnection(connectionString)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub CreateSqlConnection(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion)
            Console.WriteLine("State: {0}", connection.State)
        End Using
   End Sub
    ' </Snippet1>

End Module
