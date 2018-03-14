Option Explicit
Option Strict

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
    
Module Module1
    Sub Main()
        Dim builder As New SqlConnectionStringBuilder
        builder.DataSource = "(local)"
        builder.IntegratedSecurity = True
        builder.InitialCatalog = "AdventureWorks"
        Console.WriteLine("Initial connection string: " & builder.ConnectionString)

        builder.Clear()
        Console.WriteLine("After call to Clear, count = " & builder.Count)
        Console.WriteLine("Cleared connection string: " & builder.ConnectionString)
        Console.WriteLine()

        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
End Module
' </Snippet1>

