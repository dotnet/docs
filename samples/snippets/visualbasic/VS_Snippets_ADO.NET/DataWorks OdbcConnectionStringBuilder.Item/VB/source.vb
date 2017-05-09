Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.Odbc    

Module Module1
  Sub Main()
    Dim builder As New OdbcConnectionStringBuilder
    ' Set up a connection string for a text file.
    builder.Item("Driver") = "Microsoft Text Driver (*.txt; *.csv)"
    ' Note that Item is the default property, so 
    ' you need not include it in the reference.
    builder("dbq") = "C:\TextFilesFolder"
    builder.Item("Extension") = "asc,csv,tab,txt"

    ' Overwrite the existing value for the dbq value, 
    ' because it already exists within the collection.
    builder.Item("dbq") = "D:\"

    Console.WriteLine(builder.ConnectionString)
    Console.WriteLine()
    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

