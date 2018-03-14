' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue



        ' Provides an entry point into the application.
        '		 
        ' This example creates new transactional queues.


        Public Shared Sub Main()
            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue

            ' Create transactional queues.
            myNewQueue.CreatePublicTransactionalQueues()
            myNewQueue.CreatePrivateTransactionalQueues()

            Return

        End Sub 'Main



        ' Creates public transactional queues and sends a 
        ' message.
 

        Public Sub CreatePublicTransactionalQueues()

            ' Create and connect to a public Message Queuing queue.
            If Not MessageQueue.Exists(".\newPublicTransQueue1") Then

                ' Create the queue if it does not exist.
                MessageQueue.Create(".\newPublicTransQueue1", True)

            End If

            ' Connect to the queue.
            Dim myNewPublicQueue As New MessageQueue(".\newPublicTransQueue1")

            ' Create a transaction.
            Dim myTransaction As New MessageQueueTransaction

            ' Begin the transaction.
            myTransaction.Begin()

            ' Send the message.
            myNewPublicQueue.Send("My Message Data.", myTransaction)

            ' Commit the transaction.
            myTransaction.Commit()

            If Not MessageQueue.Exists(".\newPublicTransQueue2") Then

                ' Create (but do not connect to) a second queue.
                MessageQueue.Create(".\newPublicTransQueue2", True)
            End If

            Return

        End Sub 'CreatePublicTransactionalQueues



        ' Creates private queues and sends a message.


        Public Sub CreatePrivateTransactionalQueues()

            ' Create and connect to a private Message Queuing queue.
            If Not MessageQueue.Exists(".\Private$\newPrivTransQ1") _
                Then

                ' Create the queue if it does not exist.
                MessageQueue.Create(".\Private$\newPrivTransQ1", True)

            End If

            ' Connect to the queue.
            Dim myNewPrivateQueue As New MessageQueue(".\Private$\newPrivTransQ1")

            ' Create a transaction.
            Dim myTransaction As New MessageQueueTransaction

            ' Begin the transaction.
            myTransaction.Begin()

            ' Send the message.
            myNewPrivateQueue.Send("My Message Data.", myTransaction)

            ' Commit the transaction.
            myTransaction.Commit()

            ' Create (but do not connect to) a second private queue.
            If Not MessageQueue.Exists(".\Private$\newPrivTransQ2") _
                Then

                MessageQueue.Create(".\Private$\newPrivTransQ2", True)
            End If

            Return

        End Sub 'CreatePrivateTransactionalQueues

End Class 'MyNewQueue

' </Snippet1>