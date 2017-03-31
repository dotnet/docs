' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue


        ' Provides an entry point into the application.
        '		 
        ' This example connects to a message queue, and
        ' requests exclusive read access to the queue.
 

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Output the count of Lowest priority messages.
            myNewQueue.GetExclusiveAccess()

            Return

        End Sub 'Main


  
        ' Requests exlusive read access to the queue. If
        ' access is granted, receives a message from the 
        ' queue.
  

        Public Sub GetExclusiveAccess()

            Try

                ' Request exclusive read access to the queue.
                Dim myQueue As New MessageQueue(".\myQueue", True)

                ' Receive a message. This is where a SharingViolation 
                ' exception would be thrown.
                Dim myMessage As Message = myQueue.Receive()

            Catch e As MessageQueueException

                ' Handle request for denial of exclusive read access.
                If e.MessageQueueErrorCode = _
                    MessageQueueErrorCode.SharingViolation Then

                    Console.WriteLine("Denied exclusive read access.")

                End If

                ' Handle other sources of a MessageQueueException.

                ' Handle other exceptions as necessary.

            End Try

            Return

        End Sub 'GetExclusiveAccess

End Class 'MyNewQueue

' </Snippet1>