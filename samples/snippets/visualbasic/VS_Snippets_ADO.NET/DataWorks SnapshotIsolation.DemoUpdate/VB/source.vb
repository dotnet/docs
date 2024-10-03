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
            ' Enable Snapshot isolation in AdventureWorks
            connection1.Open()
            Dim command1 As SqlCommand = connection1.CreateCommand
            command1.CommandText = _
           "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION ON;"
            Try
                command1.ExecuteNonQuery()
                Console.WriteLine( _
                 "Snapshot Isolation turned on in AdventureWorks.")
            Catch ex As Exception
                Console.WriteLine("ALLOW_SNAPSHOT_ISOLATION failed: {0}", ex.Message)
            End Try

            ' Create a table
            command1.CommandText = _
              "IF EXISTS (SELECT * FROM sys.databases " _
              & "WHERE name=N'TestSnapshotUpdate') " _
              & "DROP TABLE TestSnapshotUpdate"
            command1.ExecuteNonQuery()
            command1.CommandText = _
              "CREATE TABLE TestSnapshotUpdate (ID int primary key, " _
              & "CharCol nvarchar(100));"
            Try
                command1.ExecuteNonQuery()
                Console.WriteLine("TestSnapshotUpdate table created.")
            Catch ex As Exception
                Console.WriteLine("CREATE TABLE failed: {0}", ex.Message)
            End Try

            ' Insert some data
            command1.CommandText = _
              "INSERT INTO TestSnapshotUpdate VALUES (1,N'abcdefg');" _
              & "INSERT INTO TestSnapshotUpdate VALUES (2,N'hijklmn');" _
              & "INSERT INTO TestSnapshotUpdate VALUES (3,N'opqrstuv');"
            Try
                command1.ExecuteNonQuery()
                Console.WriteLine("Data inserted TestSnapshotUpdate table.")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            ' Begin, but do not complete, a transaction
            ' using the Snapshot isolation level
            Dim transaction1 As SqlTransaction = Nothing
            Try
                transaction1 = connection1.BeginTransaction(IsolationLevel.Snapshot)
                command1.CommandText = _
                  "SELECT * FROM TestSnapshotUpdate WHERE ID " _
                  & "BETWEEN 1 AND 3"
                command1.Transaction = transaction1
                command1.ExecuteNonQuery()
                Console.WriteLine("Snapshot transaction1 started.")

                ' Open a second Connection/Transaction to update data
                ' using ReadCommitted. This transaction should succeed.
                Dim connection2 As SqlConnection = New SqlConnection(connectionString)
                Using connection2
                    connection2.Open()
                    Dim command2 As SqlCommand = connection2.CreateCommand()
                    command2.CommandText = "UPDATE TestSnapshotUpdate SET " _
                      & "CharCol=N'New value from Connection2' WHERE ID=1"
                    Dim transaction2 As SqlTransaction = _
                      connection2.BeginTransaction(IsolationLevel.ReadCommitted)
                    command2.Transaction = transaction2
                    Try
                        command2.ExecuteNonQuery()
                        transaction2.Commit()
                        Console.WriteLine( _
                          "transaction2 has modified data and committed.")
                    Catch ex As SqlException
                        Console.WriteLine(ex.Message)
                        transaction2.Rollback()
                    Finally
                        transaction2.Dispose()
                    End Try
                End Using

                ' Now try to update a row in Connection1/Transaction1.
                ' This transaction should fail because Transaction2
                ' succeeded in modifying the data.
                command1.CommandText = _
                  "UPDATE TestSnapshotUpdate SET CharCol=" _
                    & "N'New value from Connection1' WHERE ID=1"
                command1.Transaction = transaction1
                command1.ExecuteNonQuery()
                transaction1.Commit()
                Console.WriteLine("You should never see this.")

            Catch ex As SqlException
                Console.WriteLine("Expected failure for transaction1:")
                Console.WriteLine("  {0}: {1}", ex.Number, ex.Message)
            Finally
                transaction1.Dispose()
            End Try
        End Using

        ' CLEANUP:
        ' Turn off Snapshot isolation and delete the table
        Dim connection3 As New SqlConnection(connectionString)
        Using connection3
            connection3.Open()
            Dim command3 As SqlCommand = connection3.CreateCommand()
            command3.CommandText = _
          "ALTER DATABASE AdventureWorks SET ALLOW_SNAPSHOT_ISOLATION OFF"
            Try
                command3.ExecuteNonQuery()
                Console.WriteLine( _
                 "Snapshot isolation turned off in AdventureWorks.")
            Catch ex As Exception
                Console.WriteLine("CLEANUP FAILED: {0}", ex.Message)
            End Try

            command3.CommandText = "DROP TABLE TestSnapshotUpdate"
            Try
                command3.ExecuteNonQuery()
                Console.WriteLine("TestSnapshotUpdate table deleted.")
            Catch ex As Exception
                Console.WriteLine("CLEANUP FAILED: {0}", ex.Message)
            End Try
        End Using
        ' </Snippet1>
        Console.WriteLine("Done")
        Console.ReadLine()

    End Sub

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
