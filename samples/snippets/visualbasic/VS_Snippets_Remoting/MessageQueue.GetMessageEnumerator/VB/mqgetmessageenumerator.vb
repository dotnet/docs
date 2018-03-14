' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue


        
        ' Provides an entry point into the application.
        '		 
        ' This example uses a cursor to step through the
        ' messages in a queue and counts the number of 
        ' Lowest priority messages.
        

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Output the count of Lowest priority messages.
            myNewQueue.CountLowestPriority()

            Return

        End Sub 'Main


        
        ' Iterates through messages in a queue and examines
        ' their priority.
        

        Public Sub CountLowestPriority()

            ' Holds the count of Lowest priority messages.
            Dim numberItems As Int32 = 0

            ' Connect to a queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Get a cursor into the messages in the queue.
            Dim myEnumerator As MessageEnumerator = _
                myQueue.GetMessageEnumerator()

            ' Specify that the messages's priority should be read.
            myQueue.MessageReadPropertyFilter.Priority = True

            ' Move to the next message and examine its priority.
            While myEnumerator.MoveNext()

                ' Increase the count if the priority is Lowest.
                If myEnumerator.Current.Priority = _
                    MessagePriority.Lowest Then
                    numberItems += 1
                End If

            End While

            ' Display final count.
            Console.WriteLine(("Lowest priority messages: " + _
                numberItems.ToString()))

            Return

        End Sub 'CountLowestPriority

End Class 'MyNewQueue

' </Snippet1>