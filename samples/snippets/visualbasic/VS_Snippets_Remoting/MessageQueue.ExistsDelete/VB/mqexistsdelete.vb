' <Snippet1>
Imports System
Imports System.Messaging



Public Class MyNewQueue


        
        ' Provides an entry point into the application.
        '		 
        ' This example verifies existence and attempts to 
        ' delete a queue.
        

        Public Shared Sub Main()

            ' Determine whether the queue exists.
            If MessageQueue.Exists(".\myQueue") Then

                Try

                    ' Delete the queue.
                    MessageQueue.Delete(".\myQueue")

                Catch e As MessageQueueException

                    If e.MessageQueueErrorCode = _
                        MessageQueueErrorCode.AccessDenied Then

                        Console.WriteLine("Access is denied. " _
                            + "Queue might be a system queue.")
                    End If

                    ' Handle other sources of exceptions as necessary.

                End Try

            End If


            Return

        End Sub 'Main

End Class 'MyNewQueue 

' </Snippet1>