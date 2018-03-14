Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before running this example.
Imports System.Data.OracleClient

Module Module1
  Sub Main()
    Try
      Dim connectString As String = "Server=OracleDemo;UID=Mary;Pwd=*****"
      Console.WriteLine("Original: " & connectString)
      Dim builder As New OracleConnectionStringBuilder(connectString)
      Console.WriteLine("Modified: " & builder.ConnectionString)
      For Each key As String In builder.Keys
        Console.WriteLine(key & "=" & builder.Item(key).ToString)
      Next
      Console.WriteLine("Press any key to finish.")
      Console.ReadLine()

    Catch ex As System.Collections.Generic.KeyNotFoundException
      Console.WriteLine("KeyNotFoundException: " & ex.Message)
    Catch ex As System.FormatException
      Console.WriteLine("Format exception: " & ex.Message)
    End Try
  End Sub

End Module
' </Snippet1>

