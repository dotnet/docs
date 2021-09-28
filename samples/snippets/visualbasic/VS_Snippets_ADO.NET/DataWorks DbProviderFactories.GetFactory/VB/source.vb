Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Common

Class Program

    Shared Sub Main()

    End Sub

    ' <Snippet1>
    ' Given a provider, create a DbProviderFactory and DbConnection.
    ' Returns a DbConnection on success; Nothing on failure.
    Private Shared Function CreateDbConnection( _
        ByVal providerName As String, ByVal connectionString As String) _
        As DbConnection

        ' Assume failure.
        Dim connection As DbConnection = Nothing

        ' Create the DbProviderFactory and DbConnection.
        If Not connectionString Is Nothing Then
            Try
                Dim factory As DbProviderFactory = _
                   DbProviderFactories.GetFactory(providerName)

                connection = factory.CreateConnection()
                connection.ConnectionString = connectionString

            Catch ex As Exception
                ' Set the connection to Nothing if it was created.
                If Not connection Is Nothing Then
                    connection = Nothing
                End If
                Console.WriteLine(ex.Message)
            End Try
        End If

        ' Return the connection.
        Return connection
    End Function
    ' </Snippet1>
End Class

