Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Data.SqlClient
    
' <Snippet1>
Module Module1
    Sub Main()
        Dim builder As New SqlConnectionStringBuilder
        builder.Item("Data Source") = "(local)"
        ' Item is the default property, so 
        ' you needn't include it in the reference.
        builder("Integrated Security") = True
        builder.Item("Initial Catalog") = "AdventureWorks"

        ' Overwrite the existing value for the Data Source value.
        builder.Item("Data Source") = "."

        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()
        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
End Module
' </Snippet1>

