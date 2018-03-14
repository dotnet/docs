Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        OpenSqlConnection()
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub OpenSqlConnection()
        Dim connectionString As String = GetConnectionString()
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Console.WriteLine("State: {0}", connection.State)
            Console.WriteLine("ConnectionTimeout: {0}", connection.ConnectionTimeout)
        End Using
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file, using the
        ' System.Configuration.ConfigurationSettings.AppSettings property
        Return "Data Source=(local);Database=AdventureWorks;" _
          & "Integrated Security=SSPI;Connection Timeout=30;"
    End Function
    ' </Snippet1>
End Module
