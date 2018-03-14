'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'-----------------------------------------------------------------------

Imports System.Transactions
Imports System

Namespace Microsoft.Samples
    Public NotInheritable Class TxOutcome

        '<snippet1>
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

        '</snippet1>
    End Class
End Namespace

