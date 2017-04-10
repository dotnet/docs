Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim builder As New SqlConnectionStringBuilder
        builder.DataSource = "(local)"
        builder.IntegratedSecurity = True
        builder.InitialCatalog = "AdventureWorks"

        ' Loop through the collection of keys, displaying 
        ' the key and value for each item.
        For Each key As String In builder.Keys
            Console.WriteLine("{0}={1}", key, builder(key))
        Next

        Console.WriteLine()
        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
End Module
' </Snippet1>

