Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may have to set a reference to the System.Data.OracleClient
' assembly before running this example.
Imports System.Data.OracleClient

Module Module1
  Sub Main()
    Dim builder As New OracleConnectionStringBuilder
    builder.DataSource = "OracleSample"
    builder.IntegratedSecurity = True

    ' Loop through the collection of keys, displaying 
    ' the key and value for each item.
    For Each key As String In builder.Keys
      Console.WriteLine("{0}={1}", key, builder(key))
    Next

    Console.WriteLine()
    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

