' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue


        '
        ' Provides an entry point into the application.
        '		 
        ' This example performs asynchronous receive operation
        ' processing.
        '

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

            ' Do other work on the current thread.

            Return

        End Sub 'Main


        '
        ' Provides an event handler for the ReceiveCompleted
        ' event.
        '

        Private Shared Sub MyReceiveCompleted(ByVal [source] As _
            [Object], ByVal asyncResult As ReceiveCompletedEventArgs)

            ' Connect to the queue.
            Dim mq As MessageQueue = CType([source], MessageQueue)

            ' End the asynchronous Receive operation.
            Dim m As Message = mq.EndReceive(asyncResult.AsyncResult)

            ' Display message information on the screen.
            Console.WriteLine(("Message: " + CStr(m.Body)))

            ' Restart the asynchronous Receive operation.
            mq.BeginReceive()

            Return

        End Sub 'MyReceiveCompleted

End Class 'MyNewQueue

' </Snippet1>