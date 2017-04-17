Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim s As String = GetConnectionString()

        ChangeSqlDatabase(s)
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub ChangeSqlDatabase(ByVal connectionString As String)
        ' Assumes connectionString represents a valid connection string
        ' to the AdventureWorks sample database.
        Using connection As New SqlConnection(connectionString)

            connection.Open()
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion)
            Console.WriteLine("Database: {0}", connection.Database)

            connection.ChangeDatabase("Northwind")
            Console.WriteLine("Database: {0}", connection.Database)
        End Using
    End Sub
    ' </Snippet1>
    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file, using the
        ' System.Configuration.ConfigurationSettings.AppSettings property
        Return "Data Source=(local);Database=AdventureWorks;" _
          & "Integrated Security=SSPI;"
    End Function
End Module
