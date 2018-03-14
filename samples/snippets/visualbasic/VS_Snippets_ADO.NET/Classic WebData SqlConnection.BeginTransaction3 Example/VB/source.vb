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

            ' Start a local transaction.
            transaction = connection.BeginTransaction( _
              IsolationLevel.ReadCommitted, "SampleTransaction")

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
                transaction.Commit()
                Console.WriteLine("Both records are written to database.")
            Catch e As Exception
                Try
                    transaction.Rollback()
                Catch ex As SqlException
                    If Not transaction.Connection Is Nothing Then
                        Console.WriteLine("An exception of type " & ex.GetType().ToString() & _
                          " was encountered while attempting to roll back the transaction.")
                    End If
                End Try

                Console.WriteLine("An exception of type " & e.GetType().ToString() & _
                  "was encountered while inserting the data.")
                Console.WriteLine("Neither record was written to database.")
            End Try
        End Using
    End Sub
    ' </Snippet1>

End Module
