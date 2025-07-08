Option Explicit On
Option Strict On

Imports System.Data
Imports system.Data.SqlClient

Module Module1
    Private Sub LocalTrans(ByVal connectionString As String)
        ' <Snippet1>
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Start a local transaction.
            Dim sqlTran As SqlTransaction = connection.BeginTransaction()

            ' Enlist a command in the current transaction.
            Dim command As SqlCommand = connection.CreateCommand()
            command.Transaction = sqlTran

            Try
                ' Execute two separate commands.
                command.CommandText = _
                  "INSERT INTO Production.ScrapReason(Name) VALUES('Wrong size')"
                command.ExecuteNonQuery()
                command.CommandText = _
                  "INSERT INTO Production.ScrapReason(Name) VALUES('Wrong color')"
                command.ExecuteNonQuery()

                ' Commit the transaction
                sqlTran.Commit()
                Console.WriteLine("Both records were written to database.")

            Catch ex As Exception
                ' Handle the exception if the transaction fails to commit.
                Console.WriteLine(ex.Message)

                Try
                    ' Attempt to roll back the transaction.
                    sqlTran.Rollback()

                Catch exRollback As Exception
                    ' Throws an InvalidOperationException if the connection
                    ' is closed or the transaction has already been rolled
                    ' back on the server.
                    Console.WriteLine(exRollback.Message)
                End Try
            End Try
        End Using
        ' </Snippet1>
    End Sub
End Module
