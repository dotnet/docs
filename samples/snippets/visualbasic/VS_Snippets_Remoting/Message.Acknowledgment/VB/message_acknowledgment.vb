 ' <Snippet1>
Imports System
Imports System.Messaging


' Provides a container class for the example.

Public Class MyNewQueue
   
   

   ' Provides an entry point into the application.       
   ' This example sends and receives a message from
   ' a queue.
      
   Public Shared Sub Main()
         ' Create a new instance of the class.
         Dim myNewQueue As New MyNewQueue()
         
         ' Create new queues.
         CreateQueue(".\myQueue")
         CreateQueue(".\myAdministrationQueue")
         
         ' Send messages to a queue.
         myNewQueue.SendMessage()
         
         ' Receive messages from a queue.
         Dim messageId As String = myNewQueue.ReceiveMessage()
         
         ' Receive acknowledgment message.
         If Not (messageId Is Nothing) Then
            myNewQueue.ReceiveAcknowledgment(messageId, ".\myAdministrationQueue")
         End If
         
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
       
      
      
 
      ' Sends a string message to a queue.
 
   Public Sub SendMessage()
         
         ' Connect to a queue on the local computer.
         Dim myQueue As New MessageQueue(".\myQueue")
         
         ' Create a new message.
         Dim myMessage As New Message("Original Message")
         
         myMessage.AdministrationQueue = New MessageQueue(".\myAdministrationQueue")
         myMessage.AcknowledgeType = AcknowledgeTypes.PositiveReceive Or AcknowledgeTypes.PositiveArrival
         
         ' Send the Order to the queue.
         myQueue.Send(myMessage)
         
         Return
   End Sub 'SendMessage
      
      
      
 
      ' Receives a message containing an Order.
 
   Public Function ReceiveMessage() As String
         ' Connect to the a queue on the local computer.
         Dim myQueue As New MessageQueue(".\myQueue")
         
         myQueue.MessageReadPropertyFilter.CorrelationId = True
         
         
         ' Set the formatter to indicate body contains an Order.
         myQueue.Formatter = New XmlMessageFormatter(New Type() {GetType(String)})
         
         Dim returnString As String = Nothing
         
         Try
            ' Receive and format the message. 
            Dim myMessage As Message = myQueue.Receive()
            
            
            ' Display message information.
            Console.WriteLine("____________________________________________")
            Console.WriteLine("Original message information--")
            Console.WriteLine(("Body: " + myMessage.Body.ToString()))
            Console.WriteLine(("Id: " + myMessage.Id.ToString()))
            Console.WriteLine("____________________________________________")
            
            returnString = myMessage.Id
         
         
                  
         ' Handle invalid serialization format.
         Catch e As InvalidOperationException
            Console.WriteLine(e.Message)
         End Try
         
         ' Catch other exceptions as necessary.
         Return returnString
   End Function 'ReceiveMessage
      
      
 
      ' Receives a message containing an Order.
 
   Public Sub ReceiveAcknowledgment(messageId As String, queuePath As String)
         Dim found As Boolean = False
         Dim queue As New MessageQueue(queuePath)
         queue.MessageReadPropertyFilter.CorrelationId = True
         queue.MessageReadPropertyFilter.Acknowledgment = True
         
         Try
            While Not (queue.PeekByCorrelationId(messageId) Is Nothing)
               Dim myAcknowledgmentMessage As Message = queue.ReceiveByCorrelationId(messageId)
               
               ' Output acknowledgment message information. The correlation Id is identical
               ' to the id of the original message.
               Console.WriteLine("Acknowledgment Message Information--")
               Console.WriteLine(("Correlation Id: " + myAcknowledgmentMessage.CorrelationId.ToString()))
               Console.WriteLine(("Id: " + myAcknowledgmentMessage.Id.ToString()))
               Console.WriteLine(("Acknowledgment Type: " + myAcknowledgmentMessage.Acknowledgment.ToString()))
               Console.WriteLine("____________________________________________")
               
               found = True
            End While
         Catch e As InvalidOperationException
            ' This exception would be thrown if there is no (further) acknowledgment message
            ' with the specified correlation Id. Only output a message if there are no messages;
            ' not if the loop has found at least one.
            If found = False Then
               Console.WriteLine(e.Message)
            End If
         End Try 
   End Sub 'ReceiveAcknowledgment ' Handle other causes of invalid operation exception.
 End Class 'MyNewQueue

' </Snippet1>