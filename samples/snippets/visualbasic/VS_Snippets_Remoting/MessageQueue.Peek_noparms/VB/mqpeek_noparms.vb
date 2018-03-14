' <Snippet1>
Imports System
Imports System.Messaging



    ' This class represents an object the following example 
    ' sends to a queue and peeks from a queue.
    Public Class Order
        Public orderId As Integer
        Public orderTime As DateTime
    End Class 'Order


   
    Public Class MyNewQueue


        
        ' Provides an entry point into the application.
        '		 
        ' This example posts a notification that a message
        ' has arrived in a queue. It sends a message 
        ' containing an other to a separate queue, and then
        ' peeks the first message in the queue.
        

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Wait for a message to arrive in the queue.
            myNewQueue.NotifyArrived()

            ' Send a message to a queue.
            myNewQueue.SendMessage()

            ' Peek the first message in the queue.
            myNewQueue.PeekFirstMessage()

            Return

        End Sub 'Main


        
        ' Posts a notification when a message arrives in 
        ' the queue "monitoredQueue". Does not retrieve any 
        ' message information when peeking the message.
        
        Public Sub NotifyArrived()

            ' Connect to a queue.
            Dim myQueue As New MessageQueue(".\monitoredQueue")

            ' Specify to retrieve no message information.
            myQueue.MessageReadPropertyFilter.ClearAll()

            ' Wait for a message to arrive. 
            Dim emptyMessage As Message = myQueue.Peek()

            ' Post a notification when a message arrives.
            Console.WriteLine("A message has arrived in the queue.")

            Return

        End Sub 'NotifyArrived


        
        ' Sends an Order to a queue.
        

        Public Sub SendMessage()

            ' Create a new order and set values.
            Dim sentOrder As New Order()
            sentOrder.orderId = 3
            sentOrder.orderTime = DateTime.Now

            ' Connect to a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Send the Order to the queue.
            myQueue.Send(sentOrder)

            Return

        End Sub 'SendMessage


        
        ' Peeks a message containing an Order.
        

        Public Sub PeekFirstMessage()

            ' Connect to a queue.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Set the formatter to indicate body contains an Order.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType(Order)})

            Try

                ' Peek and format the message. 
                Dim myMessage As Message = myQueue.Peek()
                Dim myOrder As Order = CType(myMessage.Body, Order)

                ' Display message information.
                Console.WriteLine(("Order ID: " + _
                    myOrder.orderId.ToString()))
                Console.WriteLine(("Sent: " + _
                    myOrder.orderTime.ToString()))

            Catch m as MessageQueueException
                ' Handle Message Queuing exceptions.


            Catch e As InvalidOperationException
                ' Handle invalid serialization format.
                Console.WriteLine(e.Message)

                ' Catch other exceptions as necessary.

            End Try

            Return

        End Sub 'PeekFirstMessage 

End Class 'MyNewQueue

' </Snippet1>