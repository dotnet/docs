Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
' You may need to set a reference to the System.Data.OracleClient
' assembly before you can run this sample.
Imports System.Data.OracleClient

Module Module1

  Sub Main()
    Try
      Dim connectString As String = _
       "Data Source=OracleDemo;User ID=Mary;Password=*****;"

      Dim builder As New OracleConnectionStringBuilder(connectString)
      Console.WriteLine("Original: " & builder.ConnectionString)

      ' Use the Remove method
      ' in order to reset the user ID and password back to their
      ' default (empty string) values.
      builder.Remove("User ID")
      builder.Remove("Password")

      ' Turn on integrated security.
      builder.IntegratedSecurity = True

      Console.WriteLine("Modified: " & builder.ConnectionString)

    Catch ex As Exception
      Console.WriteLine(ex.Message)
    End Try

    Console.WriteLine("Press any key to finish.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

