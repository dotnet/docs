Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common

' <Snippet1>
Module Module1

    Sub Main()
        Dim builder As New DbConnectionStringBuilder
        builder.Item("Data Source") = "(local)"

        ' Item is the default property, so 
        ' you need not include it in the reference.
        builder("integrated security") = True
        builder.Item("Initial Catalog") = "AdventureWorks"

        ' Overwrite the existing value for the data source value, 
        ' because it already exists within the collection.
        builder.Item("Data Source") = "."

        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()
        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
    ' </Snippet1>


End Module
