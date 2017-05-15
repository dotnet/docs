Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before you can run this sample.
Imports System.Data.OracleClient

Module Module1
  Sub Main()
    Dim builder As New OracleConnectionStringBuilder
    builder.Item("Data Source") = "OracleDemo"
    ' Item is the default property, so 
    ' you need not include it in the reference.
    builder("integrated security") = True
    builder.Item("Unicode") = True

    ' Overwrite the existing value for the Data Source value.
    builder.Item("Data Source") = "NewOracleDemo"

    Console.WriteLine(builder.ConnectionString)
    Console.WriteLine()
    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

