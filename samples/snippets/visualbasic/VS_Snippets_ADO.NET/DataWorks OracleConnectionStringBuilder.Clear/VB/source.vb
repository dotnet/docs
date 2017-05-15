Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before running this example.
Imports System.Data.OracleClient

Module Module1
  Sub Main()
    Dim builder As New OracleConnectionStringBuilder
    builder.DataSource = "OracleSample"
    builder.IntegratedSecurity = True
    Console.WriteLine("Initial connection string: " & builder.ConnectionString)

    Console.WriteLine("Before call to Clear, count = " & builder.Count)
    builder.Clear()
    Console.WriteLine("After call to Clear, count = " & builder.Count)
    Console.WriteLine("Cleared connection string: " & builder.ConnectionString)
    Console.WriteLine()

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

