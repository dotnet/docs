Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before running this example.
Imports System.Data.OracleClient

Module Module1

  Sub Main()
    Dim builder As _
     New OracleConnectionStringBuilder( _
     "Server=OracleDemo;Integrated Security=True")

    ' Display the connection string, which should now 
    ' contains the "Data Source" key, as opposed to the 
    ' supplied "Server".
    Console.WriteLine(builder.ConnectionString)

    ' Retrieve the DataSource property.
    Console.WriteLine("DataSource = " & builder.DataSource)

    Console.WriteLine("Press any key to continue.")
    Console.ReadLine()
  End Sub

End Module
' </Snippet1>

