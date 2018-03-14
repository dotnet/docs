Option Explicit
Option Strict

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
    
Module Module1
  Sub Main()
    Try
      Dim connectString As String = _
       "Data Source=(local);User ID=ab;Password=a1Pass@@11;" & _
       "Initial Catalog=AdventureWorks"

      Dim builder As New SqlConnectionStringBuilder(connectString)
      Console.WriteLine("Original: " & builder.ConnectionString)

      ' Use the Remove method
      ' in order to reset the user ID and password back to their
      ' default (empty string) values.
      builder.Remove("User ID")
      builder.Remove("Password")

      ' Turn on integrated security:
      builder.IntegratedSecurity = True

      Console.WriteLine("Modified: " & builder.ConnectionString)

      Using connection As New SqlConnection(builder.ConnectionString)
        connection.Open()
        ' Now use the open connection.
        Console.WriteLine("Database = " & connection.Database)
      End Using

    Catch ex As Exception
      Console.WriteLine(ex.Message)
    End Try

    Console.WriteLine("Press any key to finish.")
    Console.ReadLine()
  End Sub
End Module
' </Snippet1>

