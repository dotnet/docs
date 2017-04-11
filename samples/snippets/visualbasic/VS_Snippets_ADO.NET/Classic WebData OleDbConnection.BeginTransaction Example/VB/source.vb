Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub ExecuteTransaction(ByVal connectionString As String)

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand()
            Dim transaction As OleDbTransaction

            ' Set the Connection to the new OleDbConnection.
            command.Connection = connection

            ' Open the connection and execute the transaction.
            Try
                connection.Open()

                ' Start a local transaction with ReadCommitted isolation level.
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                ' Execute the commands.
                command.CommandText = _
                    "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')"
                command.ExecuteNonQuery()
                command.CommandText = _
                    "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')"
                command.ExecuteNonQuery()

                ' Commit the transaction.
                transaction.Commit()
                Console.WriteLine("Both records are written to database.")

            Catch ex As Exception
                Console.WriteLine(ex.Message)
                ' Try to rollback the transaction
                Try
                        transaction.Rollback()

                Catch
                    ' Do nothing here; transaction is not active.
                End Try
            End Try
            ' The connection is automatically closed when the
            ' code exits the Using block.
        End Using
    End Sub
    ' </Snippet1>
End Module
