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
                  "SELECT CustomerID, CompanyName FROM Customers"

                'Create the select command.
                Dim command As DbCommand = _
                    factory.CreateCommand()
                command.CommandText = queryString
                command.Connection = connection

                ' Create the DbDataAdapter.
                Dim adapter As DbDataAdapter = _
                    factory.CreateDataAdapter()
                adapter.SelectCommand = command

                ' Create the DbCommandBuilder.
                Dim builder As DbCommandBuilder = _
                  factory.CreateCommandBuilder()
                builder.DataAdapter = adapter

                ' Get the insert, update and delete commands.
                adapter.InsertCommand = builder.GetInsertCommand()
                adapter.UpdateCommand = builder.GetUpdateCommand()
                adapter.DeleteCommand = builder.GetDeleteCommand()

                ' Display the CommandText for each command.
                Console.WriteLine("InsertCommand: {0}", _
                  adapter.InsertCommand.CommandText)
                Console.WriteLine("UpdateCommand: {0}", _
                  adapter.UpdateCommand.CommandText)
                Console.WriteLine("DeleteCommand: {0}", _
                  adapter.DeleteCommand.CommandText)

                ' Fill the DataTable
                Dim table As New DataTable
                adapter.Fill(table)

                ' Insert a new row.
                Dim newRow As DataRow = table.NewRow
                newRow("CustomerID") = "XYZZZ"
                newRow("CompanyName") = "XYZ Company"
                table.Rows.Add(newRow)

                adapter.Update(table)

                ' Display rows after insert.
                Console.WriteLine()
                Console.WriteLine("----List All Rows-----")
                Dim row As DataRow
                For Each row In table.Rows
                    Console.WriteLine("{0} {1}", row(0), row(1))
                Next
                Console.WriteLine("----After Insert-----")

                ' Edit an existing row.
                Dim editRow() As DataRow = _
                  table.Select("CustomerID = 'XYZZZ'")
                editRow(0)("CompanyName") = "XYZ Corporation"

                adapter.Update(table)

                ' Display rows after update.
                Console.WriteLine()
                For Each row In table.Rows
                    Console.WriteLine("{0} {1}", row(0), row(1))
                Next
                Console.WriteLine("----After Update-----")

                ' Delete a row.
                Dim deleteRow() As DataRow = _
                  table.Select("CustomerID = 'XYZZZ'")
                For Each row In deleteRow
                    row.Delete()
                Next

                adapter.Update(table)
                table.AcceptChanges()

                ' Display each row and column value after delete.
                Console.WriteLine()
                For Each row In table.Rows
                    Console.WriteLine("{0} {1}", row(0), row(1))
                Next
                Console.WriteLine("----After Delete-----")
                Console.WriteLine("Customer XYZZZ was deleted.")
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    '</Snippet1>

End Class
