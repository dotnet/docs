Option Explicit On
Option Strict On

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim builder As _
         New SqlConnectionStringBuilder(GetConnectionString())
        Console.WriteLine("Connection string = " & builder.ConnectionString)

        ' Keys you have provided return true.
        Console.WriteLine(builder.ContainsKey("Server"))

        ' Comparison is case insensitive, and synonyms
        ' are automatically converted to their "well-known"
        ' names.
        Console.WriteLine(builder.ContainsKey("Database"))

        ' Keys that are valid but have not been set return true.
        Console.WriteLine(builder.ContainsKey("Max Pool Size"))

        ' Keys that do not exist return false.
        Console.WriteLine(builder.ContainsKey("MyKey"))

        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file. 
        Return "Server=(local);Integrated Security=SSPI;" & _
          "Initial Catalog=AdventureWorks"
    End Function
End Module
' </Snippet1>

