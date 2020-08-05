Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.Common

Class Program

    Shared Sub Main()
    End Sub

    ' <Snippet1>
    ' Takes a DbConnection and executes an INSERT statement.
    ' Assumes SQL INSERT syntax is supported by provider.
    Private Shared Sub ExecuteDbCommand(ByVal connection As DbConnection)

        ' Check for valid DbConnection object.
        If Not connection Is Nothing Then
            Using connection
                Try
                    ' Open the connection.
                    connection.Open()

                    ' Create and execute the DbCommand.
                    Dim command As DbCommand = connection.CreateCommand()
                    command.CommandText = _
                      "INSERT INTO Categories (CategoryName) VALUES ('Low Carb')"
                    Dim rows As Integer = command.ExecuteNonQuery()

                    ' Display number of rows inserted.
                    Console.WriteLine("Inserted {0} rows.", rows)

                    ' Handle data errors.
                Catch exDb As DbException
                    Console.WriteLine("DbException.GetType: {0}", exDb.GetType())
                    Console.WriteLine("DbException.Source: {0}", exDb.Source)
                    Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode)
                    Console.WriteLine("DbException.Message: {0}", exDb.Message)

                    ' Handle all other exceptions.
                Catch ex As Exception
                    Console.WriteLine("Exception.Message: {0}", ex.Message)
                End Try
            End Using
        Else
            Console.WriteLine("Failed: DbConnection is Nothing.")
        End If
    End Sub
    ' </Snippet1>

    ' Given a provider, create the factory and connect to the data source.
    ' The provider invariant name is in the format System.Data.ProviderName.
    Private Shared Function CreateDbConnection( _
        ByVal providerName As String) As DbConnection

        ' Retrieve the connection string from the configuration file
        ' by supplying the provider name to a custom function.
        Dim connectionString As String = _
           GetConnectionStringByProvider(providerName)

        ' Create the factory if there's a valid connection string.
        If Not connectionString Is Nothing Then
            Dim factory As DbProviderFactory = _
               DbProviderFactories.GetFactory(providerName)

            ' Create and return the connection.
            Dim connection As DbConnection = factory.CreateConnection()
            connection.ConnectionString = connectionString
            Return connection
        Else
            ' Connection could not be created.
            Return Nothing
        End If
    End Function

    ' Return the connection string for the specified provider. 
    ' If there are multiple connection strings for the 
    ' same provider, the first one found is returned.
    ' Returns Nothing if the provider is not found.
    Private Shared Function GetConnectionStringByProvider( _
        ByVal providerName As String) As String

        For i As Integer = 0 To ConfigurationManager.ConnectionStrings.Count - 1
            Dim settings As ConnectionStringSettings = _
            ConfigurationManager.ConnectionStrings(i)

            If settings.ProviderName = providerName Then
                Return settings.ConnectionString
            End If
        Next

        ' Provider name not found.
        Return Nothing
    End Function
End Class
