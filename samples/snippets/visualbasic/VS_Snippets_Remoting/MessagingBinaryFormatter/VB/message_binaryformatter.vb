 ' <Snippet1>
Imports System
Imports System.Messaging
Imports System.Drawing
Imports System.IO


Namespace MyProj
    _
   
   
   Public Class MyNewQueue
      
      
      '**************************************************
      ' Provides an entry point into the application.
      '		 
      ' This example sends and receives a message from
      ' a queue.
      '**************************************************
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
      
      
      '**************************************************
      ' Creates a new queue.
      '**************************************************
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
       
      
      '**************************************************
      ' Sends an image to a queue, using the BinaryMessageFormatter.
      '**************************************************
      Public Sub SendMessage()
         Try
            
            ' Create a new bitmap.
            ' The file must be in the \bin\debug or \bin\retail folder, or
            ' you must give a full path to its location.
            Dim myImage As Image = Bitmap.FromFile("SentImage.bmp")
            
            ' Connect to a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")
            
            Dim myMessage As New Message(myImage, New BinaryMessageFormatter())
            
            ' Send the image to the queue.
            myQueue.Send(myMessage)
         Catch e As ArgumentException
            Console.WriteLine(e.Message)
         End Try 
         
         Return
      End Sub 'SendMessage
      
      
      
      '**************************************************
      ' Receives a message containing an image.
      '**************************************************
      Public Sub ReceiveMessage()
         
         Try
            
            ' Connect to the a queue on the local computer.
            Dim myQueue As New MessageQueue(".\myQueue")
            
            ' Set the formatter to indicate body contains an Order.
            myQueue.Formatter = New BinaryMessageFormatter()
            
            ' Receive and format the message. 
            Dim myMessage As System.Messaging.Message = myQueue.Receive()
            Dim myImage As Bitmap = CType(myMessage.Body, Bitmap)
            
            ' This will be saved in the \bin\debug or \bin\retail folder.
            myImage.Save("ReceivedImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
         
         
         
         'Catch
         ' Handle Message Queuing exceptions.
         
         ' Handle invalid serialization format.
         Catch e As InvalidOperationException
            Console.WriteLine(e.Message)
         
         Catch e As IOException
         End Try
         ' Handle file access exceptions.
         
         ' Catch other exceptions as necessary.
         Return
      End Sub 'ReceiveMessage
   End Class 'MyNewQueue
End Namespace 'MyProj
' </Snippet1>