Imports System.Data
Imports System.Data.OleDb

Module Module1

   Sub Main()
      Dim x As String = "Provider=SQLOLEDB;Data Source=dschwart3;Initial Catalog=AdventureWorks;" _
      & "Integrated Security=SSPI"
      OpenConnection(x)
      ChangeDatabaseConnection(x)
      Console.ReadLine()
   End Sub

   ' <Snippet1>
   Public Sub OpenConnection(ByVal connectionString As String)

      Using connection As New OleDbConnection(connectionString)
         Try
            connection.Open()
            Console.WriteLine("Server Version: {0} Database: {1}", _
                connection.ServerVersion, connection.Database)
         Catch ex As Exception
            Console.WriteLine(ex.Message)
         End Try
         ' The connection is automatically closed when the
         ' code exits the Using block.
      End Using
   End Sub
   ' </Snippet1>

   ' <Snippet2>
   Public Sub ChangeDatabaseConnection(ByVal connectionString As String)

      Using connection As New OleDbConnection(connectionString)
         Try
            connection.Open()
            Console.WriteLine("Server Version: {0} Database: {1}", _
                connection.ServerVersion, connection.Database)
            connection.ChangeDatabase("Northwind")
            Console.WriteLine("Server Version: {0} Database: {1}", _
               connection.ServerVersion, connection.Database)

         Catch ex As Exception
            Console.WriteLine(ex.Message)
         End Try
         ' The connection is automatically closed when the
         ' code exits the Using block.
      End Using
   End Sub
   ' </Snippet2>
End Module
