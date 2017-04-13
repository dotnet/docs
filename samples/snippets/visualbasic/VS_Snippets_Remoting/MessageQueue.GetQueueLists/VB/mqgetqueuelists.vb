' <Snippet1>
Imports System
Imports System.Messaging

Public Class MyNewQueue


        
        ' Provides an entry point into the application.
        '		 
        ' This example gets lists of queues by a variety
        ' of criteria.


        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Send normal and high priority messages.
            myNewQueue.GetQueuesByCategory()
            myNewQueue.GetQueuesByLabel()
            myNewQueue.GetQueuesByComputer()
            myNewQueue.GetAllPublicQueues()
            myNewQueue.GetPublicQueuesByCriteria()
            myNewQueue.GetPrivateQueues()

            Return

        End Sub 'Main



        ' Gets a list of queues with a specified category.
        ' Sends a broadcast message to all queues in that
        ' category.
 
        Public Sub GetQueuesByCategory()

            ' Get a list of queues with the specified category.
            Dim QueueList As MessageQueue() = _
                MessageQueue.GetPublicQueuesByCategory(New _
                Guid("{00000000-0000-0000-0000-000000000001}"))

            ' Send a broadcast message to each queue in the array.
            Dim queueItem As MessageQueue
            For Each queueItem In QueueList
                queueItem.Send("Broadcast message.")
            Next queueItem

            Return

        End Sub 'GetQueuesByCategory



        ' Gets a list of queues with a specified label.
        ' Sends a broadcast message to all queues with that
        ' label.


        Public Sub GetQueuesByLabel()

            ' Get a list of queues with the specified label.
            Dim QueueList As MessageQueue() = _
                MessageQueue.GetPublicQueuesByLabel("My Label")

            ' Send a broadcast message to each queue in the array.
            Dim queueItem As MessageQueue
            For Each queueItem In QueueList
                queueItem.Send("Broadcast message.")
            Next queueItem

            Return

        End Sub 'GetQueuesByLabel



        ' Gets a list of queues on a specified computer. 
        ' Displays the list on screen.
 

        Public Sub GetQueuesByComputer()

            ' Get a list of queues on the specified computer.
            Dim QueueList As MessageQueue() = _
                MessageQueue.GetPublicQueuesByMachine("MyComputer")

            ' Display the paths of the queues in the list.
            Dim queueItem As MessageQueue
            For Each queueItem In QueueList
                Console.WriteLine(queueItem.Path)
            Next queueItem

            Return

        End Sub 'GetQueuesByComputer



        ' Gets a list of all public queues.
       

        Public Sub GetAllPublicQueues()

            ' Get a list of public queues.
            Dim QueueList As MessageQueue() = _
                MessageQueue.GetPublicQueues()

            Return

        End Sub 'GetAllPublicQueues


 
        ' Gets a list of all public queues that match 
        ' specified criteria. Displays the list on 
        ' screen.


        Public Sub GetPublicQueuesByCriteria()

            ' Define criteria to filter the queues.
            Dim myCriteria As New MessageQueueCriteria()
            myCriteria.CreatedAfter = DateTime.Now.Subtract(New _
                TimeSpan(1, 0, 0, 0))
            myCriteria.ModifiedBefore = DateTime.Now
            myCriteria.MachineName = "."
            myCriteria.Label = "My Queue"

            ' Get a list of queues with that criteria.
            Dim QueueList As MessageQueue() = _
                MessageQueue.GetPublicQueues(myCriteria)

            ' Display the paths of the queues in the list.
            Dim queueItem As MessageQueue
            For Each queueItem In QueueList
                Console.WriteLine(queueItem.Path)
            Next queueItem

            Return

        End Sub 'GetPublicQueuesByCriteria


 
        ' Gets a list of private queues on the local 
        ' computer. Displays the list on screen.
  

        Public Sub GetPrivateQueues()

            ' Get a list of queues with the specified category.
            Dim QueueList As MessageQueue() = _
                MessageQueue.GetPrivateQueuesByMachine(".")

            ' Display the paths of the queues in the list.
            Dim queueItem As MessageQueue
            For Each queueItem In QueueList
                Console.WriteLine(queueItem.Path)
            Next queueItem

            Return

        End Sub 'GetPrivateQueues

End Class 'MyNewQueue

' </Snippet1>