        Public Shared Sub Main()
            Try
                Using scope As TransactionScope = New TransactionScope()

                    'Register for the transaction completed event for the current transaction
                    AddHandler Transaction.Current.TransactionCompleted, AddressOf Current_TransactionCompleted

                    'Perform transactional work here.

                    'Call complete on the TransactionScope based on console input
                    Dim c As ConsoleKeyInfo
                    While (True)

                        Console.Write("Complete the transaction scope? [Y|N] ")
                        c = Console.ReadKey()
                        Console.WriteLine()
                        If (c.KeyChar = "Y") Or (c.KeyChar = "y") Then
                            scope.Complete()
                            Exit While
                        ElseIf ((c.KeyChar = "N") Or (c.KeyChar = "n")) Then
                            Exit While
                        End If
                        
                    End While

                End Using
            Catch ex As TransactionException
                Console.WriteLine(ex)
            Catch
                Console.WriteLine("Cannot complete transaction")
                Throw
            End Try
        End Sub

        'Transaction completed event handler
        Private Shared Sub Current_TransactionCompleted(ByVal sender As Object, ByVal e As TransactionEventArgs)
            Console.WriteLine("A transaction has completed:")
            Console.WriteLine("ID:             {0}", e.Transaction.TransactionInformation.LocalIdentifier)
            Console.WriteLine("Distributed ID: {0}", e.Transaction.TransactionInformation.DistributedIdentifier)
            Console.WriteLine("Status:         {0}", e.Transaction.TransactionInformation.Status)
            Console.WriteLine("IsolationLevel: {0}", e.Transaction.IsolationLevel)
        End Sub
