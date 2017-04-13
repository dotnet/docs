Option Explicit
Option Strict

Imports System.Data
' <Snippet1>
Imports System.Data.Odbc    

Module Module1
  Sub Main()
    Try
      ' Build an empty instance, just to see
      ' the contents of the keys.
      DumpBuilderContents("")

      ' Create a SQL Server connection string.
      DumpBuilderContents("Driver={SQL Server};Server=(local);Database=AdventureWorks;Uid=ab;Pwd=pass@word1")

      ' Create an Access connection string.
      DumpBuilderContents("Driver={Microsoft Access Driver (*.mdb)};Dbq=C:\info.mdb;Exclusive=1;Uid=admin;Pwd=pass@word1")

      ' Create an Oracle connection string.
      DumpBuilderContents("Driver={Microsoft ODBC for Oracle};Server=OracleServer.world;Uid=Admin;Pwd=pass@word1;")

      ' Create a Sybase connection string.
      DumpBuilderContents("Driver={SYBASE ASE ODBC Driver};Srvr=SomeServer;Uid=admin;Pwd=pass@word1")

      Console.WriteLine("Press any key to finish.")
      Console.ReadLine()

    Catch ex As System.ArgumentException
      Console.WriteLine("Error: " & ex.Message)
    End Try
  End Sub

  Private Sub DumpBuilderContents(ByVal connectString As String)
    Dim builder As New OdbcConnectionStringBuilder(connectString)
    Console.WriteLine("=================")
    Console.WriteLine("Original connectString   = " & connectString)
    Console.WriteLine("builder.ConnectionString = " & builder.ConnectionString)
    For Each key As String In builder.Keys
      Console.WriteLine(key & "=" & builder.Item(key).ToString)
    Next
  End Sub
End Module
' </Snippet1>

