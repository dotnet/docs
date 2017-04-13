Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.Common

Class Program

    Shared Sub Main()
        Dim c As DbConnection = CreateDbConnection("System.Data.OleDb")
        'Dim c As DbConnection = CreateDbConnection("System.Data.SqlClient")
        DbCommandSelect(c)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    ' Takes a DbConnection and creates a DbCommand to retrieve data
    ' from the Categories table by executing a DbDataReader. 
    Private Shared Sub DbCommandSelect(ByVal connection As DbConnection)

        Dim queryString As String = _
           "SELECT CategoryID, CategoryName FROM Categories"

        ' Check for valid DbConnection.
        If Not connection Is Nothing Then
            Using connection
                Try
                    ' Create the command.
                    Dim command As DbCommand = connection.CreateCommand()
                    command.CommandText = queryString
                    command.CommandType = CommandType.Text

                    ' Open the connection.
                    connection.Open()

                    ' Retrieve the data.
                    Dim reader As DbDataReader = command.ExecuteReader()
                    Do While reader.Read()
                        Console.WriteLine("{0}. {1}", reader(0), reader(1))
                    Loop

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

        Dim i As Integer = 0
        For i = 0 To ConfigurationManager.ConnectionStrings.Count
            Dim settings As ConnectionStringSettings = _
            ConfigurationManager.ConnectionStrings(i)

            If settings.ProviderName = providerName Then
                Return settings.ConnectionString
            End If
        Next i

        ' Provider name not found.
        Return Nothing
    End Function
End Class
