' <Snippet1>
Imports System
Imports System.Messaging
Imports System.Threading




' Provides a container class for the example.

Public Class MyNewQueue

        ' Define static class members.
        Private Shared signal As New ManualResetEvent(False)
        Private Shared count As Integer = 0



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

            ' Begin the asynchronous receive operation.
            myQueue.BeginReceive()

            signal.WaitOne()

            ' Do other work on the current thread.

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

                count += 1
                If count = 10 Then
                    signal.Set()
                End If

                ' Restart the asynchronous receive operation.
                mq.BeginReceive()

            Catch
                ' Handle sources of MessageQueueException.

                ' Handle other exceptions.

            End Try

            Return

        End Sub 'MyReceiveCompleted

End Class 'MyNewQueue

' </Snippet1>