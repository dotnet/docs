    '  This function takes arguments for 2 connection strings and commands to create a transaction 
    '  involving two SQL Servers. It returns a value > 0 if the transaction is committed, 0 if the 
    '  transaction is rolled back. To test this code, you can connect to two different databases 
    '  on the same server by altering the connection string, or to another 3rd party RDBMS  
    '  by altering the code in the connection2 code block.
    Public Function CreateTransactionScope( _
      ByVal connectString1 As String, ByVal connectString2 As String, _
      ByVal commandText1 As String, ByVal commandText2 As String) As Integer

        ' Initialize the return value to zero and create a StringWriter to display results.
        Dim returnValue As Integer = 0
        Dim writer As System.IO.StringWriter = New System.IO.StringWriter

        Try
        ' Create the TransactionScope to execute the commands, guaranteeing
        '  that both commands can commit or roll back as a single unit of work.
            Using scope As New TransactionScope()
                Using connection1 As New SqlConnection(connectString1)
                    ' Opening the connection automatically enlists it in the 
                    ' TransactionScope as a lightweight transaction.
                    connection1.Open()

                    ' Create the SqlCommand object and execute the first command.
                    Dim command1 As SqlCommand = New SqlCommand(commandText1, connection1)
                    returnValue = command1.ExecuteNonQuery()
                    writer.WriteLine("Rows to be affected by command1: {0}", returnValue)

                    ' If you get here, this means that command1 succeeded. By nesting
                    ' the using block for connection2 inside that of connection1, you
                    ' conserve server and network resources as connection2 is opened
                    ' only when there is a chance that the transaction can commit.   
                    Using connection2 As New SqlConnection(connectString2)
                        ' The transaction is escalated to a full distributed
                        ' transaction when connection2 is opened.
                        connection2.Open()

                        ' Execute the second command in the second database.
                        returnValue = 0
                        Dim command2 As SqlCommand = New SqlCommand(commandText2, connection2)
                        returnValue = command2.ExecuteNonQuery()
                        writer.WriteLine("Rows to be affected by command2: {0}", returnValue)
                    End Using
                End Using

            ' The Complete method commits the transaction. If an exception has been thrown,
            ' Complete is called and the transaction is rolled back.
            scope.Complete()
            End Using
        Catch ex As TransactionAbortedException
            writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message)
        Catch ex As ApplicationException
            writer.WriteLine("ApplicationException Message: {0}", ex.Message)
        End Try

        ' Display messages.
        Console.WriteLine(writer.ToString())

        Return returnValue
    End Function