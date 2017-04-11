' <Snippet1>
Imports System
Imports System.Messaging
   
Public Class MyNewQueue


        '
        ' Provides an entry point into the application.
        ' 
        ' This example sends and receives a message from
        ' a transactional queue.
        '

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue

            ' Send a message to a queue.
            myNewQueue.SendMessageTransactional()

            ' Receive a message from a queue.
            myNewQueue.ReceiveMessageTransactional()

            Return

        End Sub 'Main


        '
        ' Sends a message to a queue.
        '

        Public Sub SendMessageTransactional()

            ' Connect to a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myTransactionalQueue")

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
            End If

            Return

        End Sub 'SendMessageTransactional


        '
        ' Receives a message containing an Order.
        '

        Public Sub ReceiveMessageTransactional()

            ' Connect to a transactional queue on the local computer.
            Dim myQueue As New MessageQueue(".\myTransactionalQueue")

            ' Set the formatter.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType([String])})

            ' Create a transaction.
            Dim myTransaction As New MessageQueueTransaction

            Try

                ' Begin the transaction.
                myTransaction.Begin()

                ' Receive the message. 
                Dim myMessage As Message = _
                    myQueue.Receive(myTransaction)
                Dim myOrder As [String] = CType(myMessage.Body, _
                    [String])

                ' Display message information.
                Console.WriteLine(myOrder)

                ' Commit the transaction.
                myTransaction.Commit()


            Catch e As MessageQueueException

                ' Handle nontransactional queues.
                If e.MessageQueueErrorCode = _
                    MessageQueueErrorCode.TransactionUsage Then

                    Console.WriteLine("Queue is not transactional.")

                End If

                ' Else catch other sources of a MessageQueueException.


                ' Roll back the transaction.
                myTransaction.Abort()


                ' Catch other exceptions as necessary, such as 
                ' InvalidOperationException, thrown when the formatter
                ' cannot deserialize the message.

            End Try

            Return

        End Sub 'ReceiveMessageTransactional

End Class 'MyNewQueue

' </Snippet1>