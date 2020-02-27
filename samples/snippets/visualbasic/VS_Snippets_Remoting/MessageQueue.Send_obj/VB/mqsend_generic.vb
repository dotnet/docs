' <Snippet1>
Imports System.Messaging

Public Class MyNewQueue


        '
        ' Provides an entry point into the application.
        ' 
        ' This example sends a message to a queue.
        '

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue

            ' Send a message to a queue.
            myNewQueue.SendMessage()

            Return

        End Sub


        '
        ' Sends a message to a queue.
        '

        Public Sub SendMessage()

            ' Connect to a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Send a message to the queue.
            If myQueue.Transactional = True Then

                ' Create a transaction.
                Dim myTransaction As New MessageQueueTransaction

                ' Begin the transaction.
                myTransaction.Begin()

                ' Send the message.
                myQueue.Send("My Message Data.", myTransaction)

                ' Commit the transaction.
                myTransaction.Commit()

            Else
                myQueue.Send("My Message Data.")
            End If

            Return

        End Sub

End Class

' </Snippet1>