Imports System.Collections.Generic
Imports System.Text
Imports System.Messaging
Imports System.Configuration


Module service

    Sub Main()
        ' Create a transaction queue using System.Messaging API
        ' You can also choose to not do this and instead create the
        ' queue using MSMQ MMC. Make sure you create a transactional queue.

        If Not MessageQueue.Exists(ConfigurationManager.AppSettings("queueName")) Then
            MessageQueue.Create(ConfigurationManager.AppSettings("queueName"), True)
        End If

        'Connect to the queue.
        Dim Queue As New MessageQueue(ConfigurationManager.AppSettings("queueName"))

        AddHandler Queue.ReceiveCompleted, AddressOf ProcessOrder
        Queue.BeginReceive()
        Console.WriteLine("Order Service is running")
        Console.ReadLine()
    End Sub

    Public Sub ProcessOrder(ByVal source As Object, ByVal asyncResult As ReceiveCompletedEventArgs)
        Try
            ' Connect to the queue.
            Dim Queue As MessageQueue = source
            ' End the asynchronous receive operation.
            Dim msg As System.Messaging.Message = Queue.EndReceive(asyncResult.AsyncResult)
            msg.Formatter = New System.Messaging.XmlMessageFormatter(New Type() {GetType(PurchaseOrder)})
            Dim po As PurchaseOrder = msg.Body
            Dim statusIndexer As New Random()
            po.Status = statusIndexer.Next(3)
            Console.WriteLine("Processing {0} ", po)
            Queue.BeginReceive()

        Catch ex As System.Exception

            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Module
