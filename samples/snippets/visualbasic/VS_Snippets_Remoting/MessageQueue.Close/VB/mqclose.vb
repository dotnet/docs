' <Snippet1>
Imports System
Imports System.Messaging

  
'Provides a container class for the example.

Public Class MyNewQueue



        ' Provides an entry point into the application.
        '	 
        ' This example closes a queue and frees its 
        ' resources.
 

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Send a message to a queue.
            myNewQueue.SendMessage()

            ' Receive a message from a queue.
            myNewQueue.ReceiveMessage()

            Return

        End Sub 'Main



        ' Sends a message to a queue.
 

        Public Sub SendMessage()

            ' Connect to a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Send a message to the queue.
            myQueue.Send("My message data1.")

            ' Explicitly release resources.
            myQueue.Close()

            ' Attempt to reacquire resources.
            myQueue.Send("My message data2.")

            Return

        End Sub 'SendMessage



        ' Receives a message from a queue.


        Public Sub ReceiveMessage()

            ' Connect to the a on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Set the formatter to indicate the body contains an 
            ' Order.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType([String])})

            Try
                ' Receive and format the message. 
                Dim myMessage1 As Message = myQueue.Receive()
                Dim myMessage2 As Message = myQueue.Receive()

            Catch
                ' Handle sources of any MessageQueueException.

                ' Catch other exceptions as necessary.

            Finally

                ' Free resources.
                myQueue.Close()

            End Try

            Return

        End Sub 'ReceiveMessage

End Class 'MyNewQueue

' </Snippet1>