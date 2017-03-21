    Private Sub ChangeSqlDatabase(ByVal connectionString As String)
        ' Assumes connectionString represents a valid connection string
        ' to the AdventureWorks sample database.
        Using connection As New SqlConnection(connectionString)

            connection.Open()
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion)
            Console.WriteLine("Database: {0}", connection.Database)

            connection.ChangeDatabase("Northwind")
            Console.WriteLine("Database: {0}", connection.Database)
        End Using
    End Sub