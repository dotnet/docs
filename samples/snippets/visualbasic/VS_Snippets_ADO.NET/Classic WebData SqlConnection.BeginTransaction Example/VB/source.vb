Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim connectionString As String = _
           "Persist Security Info=False;Integrated Security=SSPI;database=Northwind;server=(local)"
        ExecuteSqlTransaction(connectionString)
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub ExecuteSqlTransaction(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction

            ' Start a local transaction
            transaction = connection.BeginTransaction("SampleTransaction")

            ' Must assign both transaction object and connection
            ' to Command object for a pending local transaction.
            command.Connection = connection
            command.Transaction = transaction

            Try
                command.CommandText = _
                  "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')"
                command.ExecuteNonQuery()
                command.CommandText = _
                  "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')"

                command.ExecuteNonQuery()

                ' Attempt to commit the transaction.
                transaction.Commit()
                Console.WriteLine("Both records are written to database.")

            Catch ex As Exception
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
                Console.WriteLine("  Message: {0}", ex.Message)

                ' Attempt to roll back the transaction.
                Try
                    transaction.Rollback()

                Catch ex2 As Exception
                    ' This catch block will handle any errors that may have occurred
                    ' on the server that would cause the rollback to fail, such as
                    ' a closed connection.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                    Console.WriteLine("  Message: {0}", ex2.Message)
                End Try
            End Try
        End Using
    End Sub
    ' </Snippet1>

End Module
