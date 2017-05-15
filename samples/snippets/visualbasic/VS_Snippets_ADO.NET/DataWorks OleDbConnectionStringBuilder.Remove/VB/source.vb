Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.OleDb    

Module Module1

  Sub Main()
    Dim builder As New OleDbConnectionStringBuilder
    builder.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Sample.mdb;" & _
        "Jet OLEDB:System Database=C:\system.mdw;"

    Console.WriteLine(builder.ConnectionString)
    ' Try to remove an existing item.
    TryRemove(builder, "Provider")

    ' Try to remove a nonexistent item.
    TryRemove(builder, "User ID")

    ' Try to remove an existing item, 
    ' demonstrating that the search is not 
    ' case sensitive.
    TryRemove(builder, "DATA SOURCE")

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub

  Sub TryRemove(ByVal builder As OleDbConnectionStringBuilder, _
      ByVal itemToRemove As String)

    If builder.Remove(itemToRemove) Then
      Console.WriteLine("Removed '{0}'", itemToRemove)
    Else
      Console.WriteLine("Unable to remove '{0}'", itemToRemove)
    End If
    Console.WriteLine(builder.ConnectionString)
  End Sub

End Module
' </Snippet1>

