Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.OleDb    

Module Module1
  Sub Main()
    Dim builder As New OleDbConnectionStringBuilder()
    builder.ConnectionString = "Data Source=C:\Sample.mdb"

    ' Call the Add method to explicitly add key/value
    ' pairs to the internal collection.
    builder.Add("Provider", "Microsoft.Jet.Oledb.4.0")
    builder.Add("Jet OLEDB:Database Password", "MyPassword!")
    builder.Add("Jet OLEDB:System Database", "C:\Workgroup.mdb")

    ' Set up row-level locking.
    builder.Add("Jet OLEDB:Database Locking Mode", 1)

    ' Dump the contents of the "filled-in" OleDbConnectionStringBuilder
    ' to the console window.
    DumpBuilderContents(builder)

    ' Clear current values and reset known keywords to their
    ' default values.
    builder.Clear()

    ' Dump the contents of the newly emptied 
    ' OleDbConnectionStringBuilder
    ' to the console window.
    DumpBuilderContents(builder)

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub

  Private Sub DumpBuilderContents(ByVal builder As OleDbConnectionStringBuilder)
    Console.WriteLine("=================")
    Console.WriteLine("builder.ConnectionString = " & builder.ConnectionString)
    For Each key As String In builder.Keys
      Console.WriteLine(key & "=" & builder.Item(key).ToString)
    Next
  End Sub
End Module
' </Snippet1>

