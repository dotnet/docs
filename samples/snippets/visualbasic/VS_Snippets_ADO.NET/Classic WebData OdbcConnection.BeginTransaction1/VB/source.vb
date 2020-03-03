Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Odbc

Module Module1

    Sub Main()
        Dim connectionString As String

        connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"
        Call ExecuteTransaction(connectionString)
    End Sub

    ' <Snippet1>
    Public Sub ExecuteTransaction(ByVal connectionString As String)

        Using connection As New OdbcConnection(connectionString)
            Dim command As New OdbcCommand()
            Dim transaction As OdbcTransaction

            ' Set the Connection to the new OdbcConnection.
            command.Connection = connection

            ' Open the connection and execute the transaction.
            Try
                connection.Open()

                ' Start a local transaction.
                transaction = connection.BeginTransaction()

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
