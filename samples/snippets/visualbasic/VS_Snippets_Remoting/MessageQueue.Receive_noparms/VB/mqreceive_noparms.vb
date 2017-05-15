' <Snippet1>
Imports System
Imports System.Messaging

    ' This class represents an object the following example 
    ' sends to a queue and receives from a queue.
    Public Class Order
        Public orderId As Integer
        Public orderTime As DateTime
    End Class 'Order


   
    Public Class MyNewQueue


        '
        ' Provides an entry point into the application.
        '		 
        ' This example sends and receives a message from
        ' a qeue.
        '

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Send a message to a queue.
            myNewQueue.SendMessage()

            ' Receive a message from a queue.
            myNewQueue.ReceiveMessage()

            Return

        End Sub 'Main


        '
        ' Sends an Order to a queue.
        '

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


        '
        ' Receives a message containing an Order.
        '

        Public Sub ReceiveMessage()

            ' Connect to the a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Set the formatter to indicate the body contains an Order.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType(Order)})

            Try

                ' Receive and format the message. 
                Dim myMessage As Message = myQueue.Receive()
                Dim myOrder As Order = CType(myMessage.Body, Order)

                ' Display message information.
                Console.WriteLine(("Order ID: " + _
                    myOrder.orderId.ToString()))
                Console.WriteLine(("Sent: " + _
                    myOrder.orderTime.ToString()))

            Catch m As MessageQueueException
                ' Handle Message Queuing exceptions.

            Catch e As InvalidOperationException
                ' Handle invalid serialization format.
                Console.WriteLine(e.Message)


                ' Catch other exceptions as necessary.

            End Try

            Return

        End Sub 'ReceiveMessage

End Class 'MyNewQueue

' </Snippet1>