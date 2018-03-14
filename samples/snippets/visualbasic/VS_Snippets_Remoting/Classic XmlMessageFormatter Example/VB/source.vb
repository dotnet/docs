' <Snippet1>
Imports System
Imports System.Messaging



Public Class Server
    
    
    Public Shared Sub Main()
        
        Console.WriteLine("Processing Orders")
        
        Dim queuePath As String = ".\orders"
        EnsureQueueExists(queuePath)
        Dim queue As New MessageQueue(queuePath)
        CType(queue.Formatter, XmlMessageFormatter).TargetTypeNames = New String() {"Order"}
        
        While True
            Dim newOrder As Order = CType(queue.Receive().Body, Order)
            newOrder.ShipItems()
        End While
    End Sub 'Main
    
    
    ' Creates the queue if it does not already exist.
    Public Shared Sub EnsureQueueExists(path As String)
        If Not MessageQueue.Exists(path) Then
            MessageQueue.Create(path)
        End If
    End Sub 'EnsureQueueExists
End Class 'Server
' </Snippet1>

Public Class Order
   Public Sub ShipItems()
   End Sub
End Class