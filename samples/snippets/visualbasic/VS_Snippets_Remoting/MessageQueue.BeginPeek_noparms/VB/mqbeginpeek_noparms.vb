' <Snippet1>
Imports System
Imports System.Messaging





' Provides a container class for the example.
Public Class MyNewQueue



        ' Provides an entry point into the application.
        '		 
        ' This example performs asynchronous peek operation
        ' processing.


        Public Shared Sub Main()
            ' Create an instance of MessageQueue. Set its formatter.
            Dim myQueue As New MessageQueue(".\myQueue")
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType([String])})

            ' Add an event handler for the PeekCompleted event.
            AddHandler myQueue.PeekCompleted, AddressOf _
                MyPeekCompleted

            ' Begin the asynchronous peek operation.
            myQueue.BeginPeek()

            ' Do other work on the current thread.
            Return
        End Sub 'Main


        '**************************************************
        ' Provides an event handler for the PeekCompleted
        ' event.
        '**************************************************

        Private Shared Sub MyPeekCompleted(ByVal [source] As _
            [Object], ByVal asyncResult As PeekCompletedEventArgs)

            ' Connect to the queue.
            Dim mq As MessageQueue = CType([source], MessageQueue)

            ' End the asynchronous peek operation.
            Dim m As Message = mq.EndPeek(asyncResult.AsyncResult)

            ' Display message information on the screen.
            Console.WriteLine(("Message: " + CStr(m.Body)))

            ' Restart the asynchronous peek operation.
            mq.BeginPeek()

            Return

        End Sub 'MyPeekCompleted

End Class 'MyNewQueue

' </Snippet1>