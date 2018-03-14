Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections

Module Module1
    ' <Snippet1>
    Sub Main()
        Dim builder As New DbConnectionStringBuilder
        builder("Data Source") = "(local)"
        builder("integrated security") = True
        builder("Initial Catalog") = "AdventureWorks;NewValue=Bad"

        ' Obtain reference to the collection of keys.
        Dim keys As ICollection = builder.Keys

        Console.WriteLine("Keys before adding TimeOut:")
        For Each key As String In keys
            Console.WriteLine("{0}={1}", key, builder(key))
        Next

        ' Add a new item to the collection.
        builder("Timeout") = 300

        Console.WriteLine()
        Console.WriteLine("Keys after adding TimeOut:")

        ' Because the Keys property is dynamically updated, 
        ' the following loop includes the Timeout key.
        For Each key As String In keys
            Console.WriteLine("{0}={1}", key, builder(key))
        Next

        Console.WriteLine()
        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
    ' </Snippet1>
End Module
