Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before you can run this sample.
Imports System.Data.OracleClient

Module Module1
  Sub Main()
    Dim builder As _
     New OracleConnectionStringBuilder(GetConnectionString())
    Console.WriteLine("Connection string = " & builder.ConnectionString)

    ' Keys you have provided return true.
    Console.WriteLine(builder.ContainsKey("Integrated Security"))

    ' Comparison is case insensitive, and synonyms for the 
    ' keywords are translated to well-known names.
    ' The following returns True because "PWD" is a 
    ' synonym for "Password", a valid key.
    Console.WriteLine(builder.ContainsKey("PWD"))

    ' Keys that are valid but have not been set return true.
    Console.WriteLine(builder.ContainsKey("Unicode"))

    ' Keys that don't exist return false.
    Console.WriteLine(builder.ContainsKey("MyKey"))

    Console.WriteLine("Press Enter to continue.")
    Console.ReadLine()
  End Sub

  Private Function GetConnectionString() As String
    ' To avoid storing the connection string in your code,
    ' you can retrieve it from a configuration file. 
    Return "Server=OracleDemo;Integrated Security=True"
  End Function
End Module
' </Snippet1>

