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