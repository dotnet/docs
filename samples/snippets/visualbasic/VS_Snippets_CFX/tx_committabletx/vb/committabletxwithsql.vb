Imports System.Transactions
Imports System.Data
Imports Microsoft.Data.SqlClient

Namespace Microsoft.Samples

    Public NotInheritable Class CommittableTxWithSQL

        Public Shared Sub Main()

            Dim tx As CommittableTransaction
            tx = Nothing

            Try
                '<snippet1>
                tx = New CommittableTransaction

                Dim connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")
                If String.IsNullOrWhiteSpace(connectionString) Then
                    Throw New InvalidOperationException("Set the SQL_CONNECTION_STRING environment variable.")
                End If
                Using myConnection As New SqlConnection(connectionString)
                    Dim myCommand As New SqlCommand()

                    'Open the SQL connection
                    myConnection.Open()

                    'Give the transaction to SQL to enlist with
                    myConnection.EnlistTransaction(tx)

                    myCommand.Connection = myConnection

                    'Restore database to near it's original condition so sample will work correctly.
                    myCommand.CommandText = "DELETE FROM Region WHERE (RegionID = 100) OR (RegionID = 101)"
                    myCommand.ExecuteNonQuery()

                    'Insert the first record.
                    myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'MidWestern')"
                    myCommand.ExecuteNonQuery()

                    'Insert the second record.
                    myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (101, 'MidEastern')"
                    myCommand.ExecuteNonQuery()

                    'Commit or rollback the transaction
                    While (True)
                        Console.Write("Commit or Rollback? [C|R] ")
                        Dim choice = Console.ReadLine()
                        If choice Is Nothing Then
                            Throw New InvalidOperationException("Enter C to commit or R to roll back.")
                        End If

                        If String.Equals(choice, "C", StringComparison.OrdinalIgnoreCase) Then
                            tx.Commit()
                            Exit While
                        ElseIf String.Equals(choice, "R", StringComparison.OrdinalIgnoreCase) Then
                            tx.Rollback()
                            Exit While
                        End If
                    End While

                    myConnection.Close()
                End Using
                tx = Nothing
                '</snippet1>

            Catch ex As TransactionException
                'Call rollback inside the catch block
                If tx <> Nothing Then
                    tx.Rollback()
                End If
                Console.WriteLine(ex)

            Catch
                'Call rollback inside the catch block
                If tx <> Nothing Then
                    tx.Rollback()
                End If
                Console.WriteLine("Cannot complete transaction")
                Throw
            End Try
        End Sub
    End Class
End Namespace
