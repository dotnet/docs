 ' <Snippet1>
Imports System
Imports System.Messaging
Imports System.Drawing
Imports System.IO



   
' The following example 
' sends to a queue and receives from a queue.
Public Class Order
      Public orderId As Integer
      Public orderTime As DateTime
End Class 'Order

   
  
' Provides a container class for the example.

Public Class MyNewQueue
      
      

   ' Provides an entry point into the application.
   '		 
   ' This example sends and receives a message from
   ' a queue.

   Public Shared Sub Main()
      ' Create a new instance of the class.
      Dim myNewQueue As New MyNewQueue()
        
      ' Create a queue on the local computer.
      CreateQueue(".\myQueue")
         
      ' Send a message to a queue.
      myNewQueue.SendMessage()
       
      ' Receive a message from a queue.
      myNewQueue.ReceiveMessage()
         
      Return
   End Sub 'Main
      
      

      ' Creates a new queue.
   Public Shared Sub CreateQueue(queuePath As String)
      Try
         If Not MessageQueue.Exists(queuePath) Then
            MessageQueue.Create(queuePath)
         Else
            Console.WriteLine((queuePath + " already exists."))
         End If
      Catch e As MessageQueueException
         Console.WriteLine(e.Message)
      End Try
   End Sub 'CreateQueue
       
      

      ' Sends an Order to a queue.

   Public Sub SendMessage()
      Try
            
            ' Create a new order and set values.
            Dim sentOrder As New Order()
            sentOrder.orderId = 3
            sentOrder.orderTime = DateTime.Now
            
            ' Connect to a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")
            
            
            
            ' Create the new order.
            Dim myMessage As New Message(sentOrder)
            
            ' Send the order to the queue.
            myQueue.Send(myMessage)
      Catch e As ArgumentException
            Console.WriteLine(e.Message)
      End Try 
         
      Return
   End Sub 'SendMessage
      
      
      
 
      ' Receives a message containing an order.
 
   Public Sub ReceiveMessage()
         ' Connect to the a queue on the local computer.
         Dim myQueue As New MessageQueue(".\myQueue")
         
         ' Set the formatter to indicate body contains an Order.
         myQueue.Formatter = New XmlMessageFormatter(New Type() {GetType(Order)})
         
         Try
            ' Receive and format the message. 
            Dim myMessage As Message = myQueue.Receive()
            Dim myOrder As Order = CType(myMessage.Body, Order)
            
            ' Display message information.
            Console.WriteLine(("Order ID: " + myOrder.orderId.ToString()))
            Console.WriteLine(("Sent: " + myOrder.orderTime.ToString()))
         
  
         ' Handle invalid serialization format.
         Catch e As InvalidOperationException
            Console.WriteLine(e.Message)
         End Try
         
         ' Catch other exceptions as necessary.
         Return
   End Sub 'ReceiveMessage
End Class 'MyNewQueue

' </Snippet1>