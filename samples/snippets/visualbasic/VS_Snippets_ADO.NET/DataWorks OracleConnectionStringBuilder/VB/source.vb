Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before running this example.
Imports System.Data.OracleClient

Module Module1
  Sub Main()
    ' Create a new OracleConnectionStringBuilder and
    ' initialize it with a few name/value pairs.
    Dim builder As New OracleConnectionStringBuilder(GetConnectionString())

    ' Note that the input connection string used the 
    ' Server key, but the new connection string uses
    ' the well-known Data Source key instead.
    Console.WriteLine(builder.ConnectionString)

    ' Pass the OracleConnectionStringBuilder an existing 
    ' connection string, and you can retrieve and
    ' modify any of the elements.
    builder.ConnectionString = _
        "server=OracleDemo;user id=Mary;" & _
        "password=*****"
    ' Now that the connection string has been parsed,
    ' you can work with individual items.
    Console.WriteLine(builder.Password)
    builder.Password = "newPassword"
    builder.PersistSecurityInfo = True

    ' You can refer to connection keys using strings, 
    ' as well. When you use this technique (the default
    ' Item property in Visual Basic, or the indexer in C#),
    ' you can specify any synonym for the connection string key
    ' name.
    builder("Server") = "NewDemo"
    builder("Load Balance Timeout") = 1000

    ' The Item property is the default for the class, 
    ' and setting the Item property adds the value to the 
    ' dictionary, if necessary. 
    builder.Item("Integrated Security") = True
    Console.WriteLine(builder.ConnectionString)

    Console.WriteLine("Press Enter to finish.")
    Console.ReadLine()
  End Sub

  Private Function GetConnectionString() As String
    ' To avoid storing the connection string in your code,
    ' you can retrieve it from a configuration file. 
    Return "Server=OracleDemo;Integrated Security=True;" & _
      "Unicode=True"
  End Function

End Module
' </Snippet1>

