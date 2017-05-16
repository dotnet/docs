Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.OleDb    

Module Module1

  Sub Main()
    Try
      ' Build an empty instance, just to see
      ' the contents of the keys.
      DumpBuilderContents("")

      ' Create a SQL Server connection string.
      DumpBuilderContents("Provider=sqloledb;Data Source=(local);" & _
       "Initial Catalog=AdventureWorks;" & _
       "User Id=ab;Password=Password@1")

      ' Create an Access connection string.
      DumpBuilderContents("Provider=Microsoft.Jet.OLEDB.4.0;" & _
       "Data Source=C:\Sample.mdb")

      ' Create an Oracle connection string.
      DumpBuilderContents("Provider=msdaora;Data Source=SomeOracleDb;" & _
       "User Id=userName;Password=Pass@word1;")

      ' Create a Sybase connection string.
      DumpBuilderContents("Provider=ASAProv;Data source=myASA")

      Console.WriteLine("Press any key to finish.")
      Console.ReadLine()

    Catch ex As System.ArgumentException
      Console.WriteLine("Error: " & ex.Message)
    End Try
  End Sub

  Private Sub DumpBuilderContents(ByVal connectString As String)
    Dim builder As New OleDbConnectionStringBuilder(connectString)
    Console.WriteLine("=================")
    Console.WriteLine("Original connectString   = " & connectString)
    Console.WriteLine("builder.ConnectionString = " & builder.ConnectionString)
    For Each key As String In builder.Keys
      Console.WriteLine(key & "=" & builder.Item(key).ToString)
    Next
  End Sub
End Module
' </Snippet1>

