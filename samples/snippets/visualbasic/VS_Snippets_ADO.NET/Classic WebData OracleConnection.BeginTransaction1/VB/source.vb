Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Oracleclient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub RunOracleTransaction(ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            connection.Open()

            Dim command As OracleCommand = connection.CreateCommand()
            Dim transaction As OracleTransaction

            ' Start a local transaction
            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Assign transaction object for a pending local transaction
            command.Transaction = transaction

            Try
                command.CommandText = _
                    "INSERT INTO Dept (DeptNo, Dname, Loc) values (50, 'TECHNOLOGY', 'DENVER')"
                command.ExecuteNonQuery()
                command.CommandText = _
                    "INSERT INTO Dept (DeptNo, Dname, Loc) values (60, 'ENGINEERING', 'KANSAS CITY')"
                command.ExecuteNonQuery()
                transaction.Commit()
                Console.WriteLine("Both records are written to database.")
            Catch e As Exception
                transaction.Rollback()
                Console.WriteLine(e.ToString())
                Console.WriteLine("Neither record was written to database.")
            End Try
        End Using
    End Sub
    ' </Snippet1>
End Module
