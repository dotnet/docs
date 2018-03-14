' <Snippet1>
Imports System
Imports System.Messaging



   
    Public Class MyNewQueue


        '
        ' Provides an entry point into the application.
        '		 
        ' This example determines whether a queue is empty.
        '

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Determine whether a queue is empty.
            Dim IsQueueEmpty As Boolean = myNewQueue.IsQueueEmpty()
	    if IsQueueEMpty=True Then Console.WriteLine("Empty")
            

            Return

        End Sub 'Main


        '
        ' Determines whether a queue is empty. The Peek()
        ' method throws an exception if there is no message
        ' in the queue. This method handles that exception 
        ' by returning true to the calling method.
        '

        Public Function IsQueueEmpty() As Boolean

            'Dim QueueEmpty As Boolean = False

            ' Connect to a queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            Try

                ' Set Peek to return immediately.
                myQueue.Peek(New TimeSpan(0))

                ' If an IOTimeout was not thrown, there is a message 
                ' in the queue.
                'queueEmpty = False

            Catch e As MessageQueueException

                If e.MessageQueueErrorCode = _
                    MessageQueueErrorCode.IOTimeout Then

                    ' No message was in the queue.
                    IsQueueEmpty = True

                End If

                ' Handle other sources of MessageQueueException as necessary.

                ' Handle other exceptions as necessary.

            End Try

            ' Return true if there are no messages in the queue.
            'Return queueEmpty
	    IsQueueEmpty = False

        End Function 'IsQueueEmpty 

End Class 'MyNewQueue

' </Snippet1>