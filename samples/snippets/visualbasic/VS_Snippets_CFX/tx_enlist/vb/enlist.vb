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
Namespace Microsoft.Samples

    Public NotInheritable Class VolatileEnlist

        '<snippet1>
        Public Shared Sub Main()
            Try
                Using scope As TransactionScope = New TransactionScope()

                    'Create an enlistment object
                    Dim myEnlistmentClass As New EnlistmentClass

                    'Enlist on the current transaction with the enlistment object
                    Transaction.Current.EnlistVolatile(myEnlistmentClass, EnlistmentOptions.None)

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
    End Class

    '<snippet2>
    Public Class EnlistmentClass
        Implements IEnlistmentNotification

        Public Sub Prepare(ByVal myPreparingEnlistment As PreparingEnlistment) Implements System.Transactions.IEnlistmentNotification.Prepare
            Console.WriteLine("Prepare notification received")

            'Perform transactional work

            'If work finished correctly, reply with prepared
            myPreparingEnlistment.Prepared()
        End Sub

        Public Sub Commit(ByVal myEnlistment As Enlistment) Implements System.Transactions.IEnlistmentNotification.Commit
            Console.WriteLine("Commit notification received")

            'Do any work necessary when commit notification is received

            'Declare done on the enlistment
            myEnlistment.Done()
        End Sub

        Public Sub Rollback(ByVal myEnlistment As Enlistment) Implements System.Transactions.IEnlistmentNotification.Rollback
            Console.WriteLine("Rollback notification received")

            'Do any work necessary when rollback notification is received

            'Declare done on the enlistment
            myEnlistment.Done()
        End Sub

        Public Sub InDoubt(ByVal myEnlistment As Enlistment) Implements System.Transactions.IEnlistmentNotification.InDoubt
            Console.WriteLine("In doubt notification received")

            'Do any work necessary when in doubt notification is received

            'Declare done on the enlistment
            myEnlistment.Done()
        End Sub
    End Class
    '</snippet2>

    '</snippet1>
End Namespace

