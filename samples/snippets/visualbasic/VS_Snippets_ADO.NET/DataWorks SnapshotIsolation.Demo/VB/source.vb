Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        ' <Snippet1>
        ' Assumes GetConnectionString returns a valid connection string
        ' where pooling is turned off by setting Pooling=False;.
        Dim connectionString As String = GetConnectionString()

        Using connection1 As New SqlConnection(connectionString)
            ' Drop the TestSnapshot table if it exists
            connection1.Open()
            Dim command1 As SqlCommand = connection1.CreateCommand
            command1.CommandText = "IF EXISTS " & _
            "(SELECT * FROM sys.tables WHERE name=N'TestSnapshot') " _
              & "DROP TABLE TestSnapshot"
            Try
                command1.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            ' Enable SNAPSHOT isolation
            command1.CommandText = _
            "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION ON"
            command1.ExecuteNonQuery()

            ' Create a table named TestSnapshot and insert one row of data
            command1.CommandText = _
            "CREATE TABLE TestSnapshot (ID int primary key, valueCol int)"
            command1.ExecuteNonQuery()
            command1.CommandText = _
              "INSERT INTO TestSnapshot VALUES (1,1)"
            command1.ExecuteNonQuery()

            ' Begin, but do not complete, a transaction to update the data
            ' with the Serializable isolation level, which locks the table
            ' pending the commit or rollback of the update. The original
            ' value in valueCol was 1, the proposed new value is 22.
            Dim transaction1 As SqlTransaction = _
              connection1.BeginTransaction(IsolationLevel.Serializable)
            command1.Transaction = transaction1
            command1.CommandText = _
             "UPDATE TestSnapshot SET valueCol=22 WHERE ID=1"
            command1.ExecuteNonQuery()

            ' Open a second connection to AdventureWorks
            Dim connection2 As SqlConnection = New SqlConnection(connectionString)
            Using connection2
                connection2.Open()

                ' Initiate a second transaction to read from TestSnapshot
                ' using Snapshot isolation. This will read the original
                ' value of 1 since transaction1 has not yet committed.
                Dim command2 As SqlCommand = connection2.CreateCommand()
                Dim transaction2 As SqlTransaction = _
                  connection2.BeginTransaction(IsolationLevel.Snapshot)
                command2.Transaction = transaction2
                command2.CommandText = _
                    "SELECT ID, valueCol FROM TestSnapshot"
                Dim reader2 As SqlDataReader = _
                    command2.ExecuteReader()
                While reader2.Read()
                    Console.WriteLine("Expected 1,1 Actual " _
                      & reader2.GetValue(0).ToString() + "," _
                      & reader2.GetValue(1).ToString())
                End While
                transaction2.Commit()
            End Using

            ' Open a third connection to AdventureWorks and
            ' initiate a third transaction to read from TestSnapshot
            ' using the ReadCommitted isolation level. This transaction
            ' will not be able to view the data because of
            ' the locks placed on the table in transaction1
            ' and will time out after 4 seconds.
            ' You would see the same behavior with the
            ' RepeatableRead or Serializable isolation levels.
            Dim connection3 As SqlConnection = New SqlConnection(connectionString)
            Using connection3
                connection3.Open()
                Dim command3 As SqlCommand = connection3.CreateCommand()
                Dim transaction3 As SqlTransaction = _
                    connection3.BeginTransaction(IsolationLevel.ReadCommitted)
                command3.Transaction = transaction3
                command3.CommandText = _
                    "SELECT ID, valueCol FROM TestSnapshot"
                command3.CommandTimeout = 4

                Try
                    Dim reader3 As SqlDataReader = command3.ExecuteReader()
                    While reader3.Read()
                        Console.WriteLine("You should never hit this.")
                    End While
                    transaction3.Commit()
                Catch ex As Exception
                    Console.WriteLine("Expected timeout expired exception: " _
                      & ex.Message)
                    transaction3.Rollback()
                End Try
            End Using

            ' Open a fourth connection to AdventureWorks and
            ' initiate a fourth transaction to read from TestSnapshot
            ' using the ReadUncommitted isolation level. ReadUncommitted
            ' will not hit the table lock, and will allow a dirty read
            ' of the proposed new value 22. If the first transaction
            ' transaction rolls back, this value will never actually have
            ' existed in the database.
            Dim connection4 As SqlConnection = New SqlConnection(connectionString)
            Using connection4
                connection4.Open()
                Dim command4 As SqlCommand = connection4.CreateCommand()
                Dim transaction4 As SqlTransaction = _
                  connection4.BeginTransaction(IsolationLevel.ReadUncommitted)
                command4.Transaction = transaction4
                command4.CommandText = _
                    "SELECT ID, valueCol FROM TestSnapshot"
                Dim reader4 As SqlDataReader = _
                    command4.ExecuteReader()
                While reader4.Read()
                    Console.WriteLine("Expected 1,22 Actual " _
                      & reader4.GetValue(0).ToString() _
                      & "," + reader4.GetValue(1).ToString())
                End While
                transaction4.Commit()

                ' Rollback transaction1
                transaction1.Rollback()
            End Using
        End Using

        ' CLEANUP
        ' Drop TestSnapshot table and set
        ' ALLOW_SNAPSHOT_ISOLATION OFF for AdventureWorks
        Dim connection5 As New SqlConnection(connectionString)
        Using connection5
            connection5.Open()
            Dim command5 As SqlCommand = connection5.CreateCommand()
            command5.CommandText = "DROP TABLE TestSnapshot"
            Dim command6 As SqlCommand = connection5.CreateCommand()
            command6.CommandText = _
           "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION OFF"
            Try
                command5.ExecuteNonQuery()
                command6.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
        ' </Snippet1>
    End Sub

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
