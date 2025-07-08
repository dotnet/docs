Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.Common

Class Program

    '<Snippet1>
    Shared Sub CreateDataAdapter(ByVal providerName As String, _
        ByVal connectionString As String)

        ' Create the DbProviderFactory and DbConnection.
        Try
            Dim factory As DbProviderFactory = _
               DbProviderFactories.GetFactory(providerName)

            Dim connection As DbConnection = _
                factory.CreateConnection()
            connection.ConnectionString = connectionString
            Using connection

                ' Define the query.
                Dim queryString As String = _
                  "SELECT CategoryName FROM Categories"

                'Create the DbCommand.
                Dim command As DbCommand = _
                    factory.CreateCommand()
                command.CommandText = queryString
                command.Connection = connection

                ' Create the DbDataAdapter.
                Dim adapter As DbDataAdapter = _
                    factory.CreateDataAdapter()
                adapter.SelectCommand = command

                ' Fill the DataTable
                Dim table As New DataTable
                adapter.Fill(table)

                'Display each row and column value.
                Dim row As DataRow
                Dim column As DataColumn
                For Each row In table.Rows
                    For Each column In table.Columns
                        Console.WriteLine(row(column))
                    Next
                Next
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    '</Snippet1>

End Class
