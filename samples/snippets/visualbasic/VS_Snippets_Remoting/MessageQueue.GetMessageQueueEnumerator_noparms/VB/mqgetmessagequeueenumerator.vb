' <Snippet1>
Imports System
Imports System.Messaging



Public Class MyNewQueue


        
        ' Provides an entry point into the application.
        '		 
        ' This example uses a cursor to step through the
        ' message queues and list the public queues on the
        ' network.
        

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Output the count of Lowest priority messages.
            myNewQueue.ListPublicQueues()

            Return

        End Sub 'Main


        
        ' Iterates through message queues and examines the
        ' path for each queue. Also displays the number of
        ' public queues on the network.
        

        Public Sub ListPublicQueues()

            ' Holds the count of private queues.
            Dim numberQueues As Int32 = 0

            ' Get a cursor into the queues on the network.
            Dim myQueueEnumerator As MessageQueueEnumerator = _
                MessageQueue.GetMessageQueueEnumerator()

            ' Move to the next queue and read its path.
            While myQueueEnumerator.MoveNext()
                ' Increase the count if the priority is Lowest.
                Console.WriteLine(myQueueEnumerator.Current.Path)
                numberQueues += 1
            End While

            ' Display final count.
            Console.WriteLine(("Number of public queues: " + _
                numberQueues.ToString()))

            Return

        End Sub 'ListPublicQueues

End Class 'MyNewQueue

' </Snippet1>