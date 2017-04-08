Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common
Module Module1
    ' <Snippet1>
    Sub Main()
        Dim builder As New DbConnectionStringBuilder
        builder.ConnectionString = _
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Demo.mdb;" & _
            "Jet OLEDB:System Database=system.mdw;"

        ' Try to remove an existing item.
        TryRemove(builder, "Provider")

        ' Try to remove a nonexistent item.
        TryRemove(builder, "User ID")

        ' Try to remove an existing item, 
        ' demonstrating that the search isn't 
        ' case sensitive.
        TryRemove(builder, "DATA SOURCE")
        Console.ReadLine()
    End Sub

    Sub TryRemove(ByVal builder As DbConnectionStringBuilder, _
        ByVal itemToRemove As String)

        If builder.Remove(itemToRemove) Then
            Console.WriteLine("Removed '{0}'", itemToRemove)
        Else
            Console.WriteLine("Unable to remove '{0}'", itemToRemove)
        End If
        Console.WriteLine(builder.ConnectionString)
    End Sub
    ' </Snippet1>
End Module
