' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue



        ' Provides an entry point into the application.
        '		 
        ' This example specifies different types of default
        ' properties for messages.


        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Send normal and high priority messages.
            myNewQueue.SendNormalPriorityMessages()
            myNewQueue.SendHighPriorityMessages()

            Return

        End Sub 'Main



        ' Associates selected message property values
        ' with high priority messages.
 

        Public Sub SendHighPriorityMessages()

            ' Connect to a message queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Associate selected default property values with high
            ' priority messages.
            myQueue.DefaultPropertiesToSend.Priority = _
                MessagePriority.High
            myQueue.DefaultPropertiesToSend.Label = _
                "High Priority Message"
            myQueue.DefaultPropertiesToSend.Recoverable = True
            myQueue.DefaultPropertiesToSend.TimeToReachQueue = _
                New TimeSpan(0, 0, 30)

            ' Send messages using these defaults.
            myQueue.Send("High priority message data 1.")
            myQueue.Send("High priority message data 2.")
            myQueue.Send("High priority message data 3.")

            Return

        End Sub 'SendHighPriorityMessages



        ' Associates selected message property values
        ' with normal priority messages.

        Public Sub SendNormalPriorityMessages()

            ' Connect to a message queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Associate selected default property values with normal
            ' priority messages.
            myQueue.DefaultPropertiesToSend.Priority = _
                MessagePriority.Normal
            myQueue.DefaultPropertiesToSend.Label = _
                "Normal Priority Message"
            myQueue.DefaultPropertiesToSend.Recoverable = False
            myQueue.DefaultPropertiesToSend.TimeToReachQueue = _
                New TimeSpan(0, 2, 0)

            ' Send messages using these defaults.
            myQueue.Send("Normal priority message data 1.")
            myQueue.Send("Normal priority message data 2.")
            myQueue.Send("Normal priority message data 3.")

            Return

        End Sub 'SendNormalPriorityMessages

End Class 'MyNewQueue

' </Snippet1>