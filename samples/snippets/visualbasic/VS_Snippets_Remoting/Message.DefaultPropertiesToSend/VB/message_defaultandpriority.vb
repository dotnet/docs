' <Snippet1>
Imports System
Imports System.Messaging


'Provides a container class for the example.
Public Class MyNewQueue
      
      

      ' Provides an entry point into the application.
      '		 
      ' This example sends and receives a message from
      ' a queue.

      Public Shared Sub Main()
         ' Create a new instance of the class.
         Dim myNewQueue As New MyNewQueue()
         
         ' Send messages to a queue.
         myNewQueue.SendMessage(MessagePriority.Normal, "First Message Body.")
         myNewQueue.SendMessage(MessagePriority.Highest, "Second Message Body.")
         
         ' Receive messages from a queue.
         myNewQueue.ReceiveMessage()
         myNewQueue.ReceiveMessage()
         
         Return
      End Sub 'Main
      
      
      

      ' Sends a string message to a queue.

      Public Sub SendMessage(priority As MessagePriority, messageBody As String)
         
         ' Connect to a queue on the local computer.
         Dim myQueue As New MessageQueue(".\myQueue")
         
         ' Create a new message.
         Dim myMessage As New Message()
         
         If priority > MessagePriority.Normal Then
            myMessage.Body = "High Priority: " + messageBody
         Else
            myMessage.Body = messageBody
         End If 
         ' Set the priority of the message.
         myMessage.Priority = priority
         
         
         ' Send the Order to the queue.
         myQueue.Send(myMessage)
         
         Return
      End Sub 'SendMessage
      
      
      

      ' Receives a message.

      Public Sub ReceiveMessage()
         ' Connect to the a queue on the local computer.
         Dim myQueue As New MessageQueue(".\myQueue")
         
         ' Set the queue to read the priority. By default, it
         ' is not read.
         myQueue.MessageReadPropertyFilter.Priority = True
         
         ' Set the formatter to indicate body contains a string.
         myQueue.Formatter = New XmlMessageFormatter(New Type() {GetType(String)})
         
         Try
            ' Receive and format the message. 
            Dim myMessage As Message = myQueue.Receive()
            
            ' Display message information.
            Console.WriteLine(("Priority: " + myMessage.Priority.ToString()))
            Console.WriteLine(("Body: " + myMessage.Body.ToString()))
         
         
         
         ' Handle invalid serialization format.
         Catch e As InvalidOperationException
            Console.WriteLine(e.Message)
         End Try
         
         ' Catch other exceptions as necessary.
         Return
      End Sub 'ReceiveMessage
   End Class 'MyNewQueue

' </Snippet1>