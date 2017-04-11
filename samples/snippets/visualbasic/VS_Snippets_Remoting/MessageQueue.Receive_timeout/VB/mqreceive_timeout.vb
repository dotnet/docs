' <Snippet1>
Imports System
Imports System.Messaging

' This class represents an object the following example 
' receives from a queue.
Public Class Order
        Public orderId As Integer
        Public orderTime As DateTime
End Class 'Order


   
Public Class MyNewQueue


        '
        ' Provides an entry point into the application.
        '		 
        ' This example receives a message from a queue.
        '

        Public Shared Sub Main()

            ' Create a new instance of the class.
            Dim myNewQueue As New MyNewQueue()

            ' Receive a message from a queue.
            myNewQueue.ReceiveMessage()

            Return

        End Sub 'Main


        '
        ' Receives a message containing an Order.
        '

        Public Sub ReceiveMessage()

            ' Connect to the a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")

            ' Set the formatter to indicate body contains an Order.
            myQueue.Formatter = New XmlMessageFormatter(New Type() _
                {GetType(Order)})

            Try

                ' Receive and format the message. 
                ' Wait 5 seconds for a message to arrive.
                Dim myMessage As Message = myQueue.Receive(New _
                    TimeSpan(0, 0, 5))
                Dim myOrder As Order = CType(myMessage.Body, Order)

                ' Display message information.
                Console.WriteLine(("Order ID: " + _
                    myOrder.orderId.ToString()))
                Console.WriteLine(("Sent: " + _
                    myOrder.orderTime.ToString()))

            Catch e As MessageQueueException
                ' Handle no message arriving in the queue.
                If e.MessageQueueErrorCode = _
                    MessageQueueErrorCode.IOTimeout Then

                    Console.WriteLine("No message arrived in queue.")

                End If

                ' Handle other sources of a MessageQueueException.

            Catch e As InvalidOperationException
                ' Handle invalid serialization format.
                Console.WriteLine(e.Message)

                ' Catch other exceptions as necessary.

            End Try

            Return

        End Sub 'ReceiveMessage

End Class 'MyNewQueue

' </Snippet1>