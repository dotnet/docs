Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.Odbc  
  
Module Module1
  Sub Main()
    Dim builder As New OdbcConnectionStringBuilder
    builder.ConnectionString = _
     "Driver={SQL Server};Server=(local);" & _
     "Database=AdventureWorks;Trusted_Connection=yes;"

    Console.WriteLine(builder.ConnectionString)

    ' Try to remove an existing item.
    TryRemove(builder, "Server")

    ' Try to remove a nonexistent item.
    TryRemove(builder, "User ID")

    ' Try to remove an existing item, 
    ' demonstrating that the search is not 
    ' case sensitive.
    TryRemove(builder, "DATABASE")

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub

  Sub TryRemove(ByVal builder As OdbcConnectionStringBuilder, _
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

