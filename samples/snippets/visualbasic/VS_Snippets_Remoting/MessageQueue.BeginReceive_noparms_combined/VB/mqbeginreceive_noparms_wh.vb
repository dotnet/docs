' <Snippet2>
Imports System
Imports System.Messaging
Imports System.Threading


' Provides a container class for the example.

Public Class MyNewQueue


        ' Provides an entry point into the application.
        '		 
        ' This example performs asynchronous receive
        ' operation processing.


        Public Shared Sub Main()

            ' Create an instance of MessageQueue. Set its formatter.
            Dim myQueue As New MessageQueue(".\myQueue")
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType([String])})

            ' Add an event handler for the ReceiveCompleted event.
            AddHandler myQueue.ReceiveCompleted, AddressOf _
                MyReceiveCompleted

            ' Define wait handles for multiple operations.
            Dim waitHandleArray(10) As WaitHandle

            Dim i As Integer
            For i = 0 To 9
                ' Begin asynchronous operations.
                waitHandleArray(i) = _
                    myQueue.BeginReceive().AsyncWaitHandle
            Next i

            ' Specify to wait for all operations to return.
            WaitHandle.WaitAll(waitHandleArray)

            Return

        End Sub 'Main



        ' Provides an event handler for the ReceiveCompleted
        ' event.


        Private Shared Sub MyReceiveCompleted(ByVal [source] As _
            [Object], ByVal asyncResult As ReceiveCompletedEventArgs)

            Try
                ' Connect to the queue.
                Dim mq As MessageQueue = CType([source], MessageQueue)

                ' End the asynchronous receive operation.
                Dim m As Message = _
                    mq.EndReceive(asyncResult.AsyncResult)

                ' Process the message here.
                Console.WriteLine("Message received.")

            Catch

                ' Handle sources of MessageQueueException.

                ' Handle other exceptions.

            End Try

            Return

        End Sub 'MyReceiveCompleted

End Class 'MyNewQueue

' </Snippet2>