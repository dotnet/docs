' <Snippet1>
Imports System
Imports System.Messaging

' Provides a container class for the example.

Public Class MyNewQueue


  
        ' Provides an entry point into the application.
        '		 
        ' This example creates new public and private 
        ' queues.
 

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Create public and private queues.
            myNewQueue.CreatePublicQueues()
            myNewQueue.CreatePrivateQueues()

            Return

        End Sub 'Main


 
        ' Creates public queues and sends a message.
 

        Public Sub CreatePublicQueues()

            ' Create and connect to a public Message Queuing queue.
            If Not MessageQueue.Exists(".\newPublicQueue") Then
                ' Create the queue if it does not exist.
                Dim myNewPublicQueue As MessageQueue = _
                    MessageQueue.Create(".\newPublicQueue")

                ' Send a message to the queue.
                myNewPublicQueue.Send("My message data.")
            End If

            ' Create (but do not connect to) a second public queue.
            If Not MessageQueue.Exists(".\newPublicResponseQueue") _
                Then

                MessageQueue.Create(".\newPublicResponseQueue")
            End If

            Return

        End Sub 'CreatePublicQueues



        ' Creates private queues and sends a message.


        Public Sub CreatePrivateQueues()

            ' Create and connect to a private Message Queuing queue.
            If Not MessageQueue.Exists(".\Private$\newPrivateQueue") _
                Then

                ' Create the queue if it does not exist.
                Dim myNewPrivateQueue As MessageQueue = _
                    MessageQueue.Create(".\Private$\newPrivateQueue")

                ' Send a message to the queue.
                myNewPrivateQueue.Send("My message data.")
            End If

            ' Create (but do not connect to) a second private queue.
            If Not MessageQueue.Exists(".\Private$\newResponseQueue") _
                Then

                MessageQueue.Create(".\Private$\newResponseQueue")
            End If

            Return

        End Sub 'CreatePrivateQueues

End Class 'MyNewQueue

' </Snippet1>