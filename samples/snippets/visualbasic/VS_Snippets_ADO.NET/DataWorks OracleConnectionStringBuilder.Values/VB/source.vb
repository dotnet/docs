Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient 
' assembly in order to run this example.
Imports System.Data.OracleClient

Module Module1
  Sub Main()
    Dim builder As _
     New OracleConnectionStringBuilder(GetConnectionString())

    ' Loop through each of the values, displaying the contents.
    For Each value As Object In builder.Values
      Console.WriteLine(value)
    Next

    Console.WriteLine("Press any key to continue.")
    Console.ReadLine()
  End Sub

  Private Function GetConnectionString() As String
    ' To avoid storing the connection string in your code,
    ' you can retrieve it from a configuration file. 
    Return "Data Source=OracleSample;Integrated Security=true;" & _
      "Persist Security Info=True; Max Pool Size=100; Min Pool Size=1"
  End Function
End Module
' </Snippet1>

