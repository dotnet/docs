' <Snippet1>
Imports System
Imports System.Messaging

 
Public Class MyNewQueue


        '
        ' Provides an entry point into the application.
        '		 
        ' This example uses a cursor to step through the
        ' message queues and list the public queues on the
        ' network that specify certain criteria.
        

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Output the count of Lowest priority messages.
            myNewQueue.ListPublicQueuesByCriteria()

            Return

        End Sub 'Main


        
        ' Iterates through message queues and displays the
        ' path of each queue that was created in the last
        ' day and that exists on the computer "MyComputer". 
        

        Public Sub ListPublicQueuesByCriteria()

            Dim numberQueues As Int32 = 0

            ' Specify the criteria to filter by.
            Dim myCriteria As New MessageQueueCriteria()
            myCriteria.MachineName = "MyComputer"
            myCriteria.CreatedAfter = DateTime.Now.Subtract(New _
                TimeSpan(1, 0, 0, 0))


            ' Get a cursor into the queues on the network.
            Dim myQueueEnumerator As MessageQueueEnumerator = _
                MessageQueue.GetMessageQueueEnumerator(myCriteria)

            ' Move to the next queue and read its path.
            While myQueueEnumerator.MoveNext()
                ' Increase the count if the priority is Lowest.
                Console.WriteLine(myQueueEnumerator.Current.Path)
                numberQueues += 1
            End While

            ' Handle no queues matching the criteria.
            If numberQueues = 0 Then
                Console.WriteLine("No queues match the criteria.")
            End If

            Return

        End Sub 'ListPublicQueuesByCriteria

End Class 'MyNewQueue

' </Snippet1>