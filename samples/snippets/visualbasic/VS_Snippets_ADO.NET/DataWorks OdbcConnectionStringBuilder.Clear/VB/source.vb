Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.Odbc    

Module Module1
  Sub Main()
    Dim builder As New OdbcConnectionStringBuilder()

    ' Call the Add method to explicitly add key/value
    ' pairs to the internal collection.
    builder.Driver = "Microsoft Excel Driver (*.xls)"
    builder("Dbq") = "C:\Data.xls"
    builder("DriverID") = "790"
    builder("DefaultDir") = "C:\"

    ' Dump the contents of the "filled-in" OdbcConnectionStringBuilder
    ' to the console window.
    DumpBuilderContents(builder)

    ' Clear current values and reset known keys to their
    ' default values.
    builder.Clear()

    ' Dump the contents of the newly emptied 
    ' OdbcConnectionStringBuilder
    ' to the console window.
    DumpBuilderContents(builder)

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub

  Private Sub DumpBuilderContents(ByVal builder As OdbcConnectionStringBuilder)
    Console.WriteLine("=================")
    Console.WriteLine("builder.ConnectionString = " & builder.ConnectionString)
    For Each key As String In builder.Keys
      Console.WriteLine(key & "=" & builder.Item(key).ToString)
    Next
  End Sub
End Module
' </Snippet1>

