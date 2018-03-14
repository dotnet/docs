' <Snippet3>
Imports System
Imports System.Messaging

Class Client
    
    
    Public Shared Sub Main()
        
        Dim queuePath As String = ".\orders"
        EnsureQueueExists(queuePath)
        Dim queue As New MessageQueue(queuePath)
        
        Dim orderRequest As New Order()
        orderRequest.itemId = 1025
        orderRequest.quantity = 5
        orderRequest.address = "One Microsoft Way"
        
        queue.Send(orderRequest)
        ' This line uses a new method you define on the Order class:
        ' orderRequest.PrintReceipt()

    End Sub 'Main
    
    ' Creates the queue if it does not already exist.
    Public Shared Sub EnsureQueueExists(path As String)
        If Not MessageQueue.Exists(path) Then
            MessageQueue.Create(path)
        End If
    End Sub 'EnsureQueueExists
End Class 'Client 
' </Snippet3>

Public Class Order
   Public itemId as Integer
   Public quantity as Integer
   Public address as String

   Public Sub ShipItems()
   End Sub
End Class