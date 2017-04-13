Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Messaging
Imports System.Configuration
Imports System.Transactions


Module Client

    Sub Main()
        'Connect to the queue.
        Dim orderQueue As New MessageQueue("FormatName:Direct=OS:" + ConfigurationManager.AppSettings("orderQueueName"))

        ' Create the purchase order.
        Dim po As New PurchaseOrder()
        po.customerId = "somecustomer.com"
        po.poNumber = Guid.NewGuid().ToString()

        Dim lineItem1 As New PurchaseOrderLineItem()
        lineItem1.productId = "Blue Widget"
        lineItem1.quantity = 54
        lineItem1.unitCost = 29.99F

        Dim lineItem2 As New PurchaseOrderLineItem()
        lineItem2.productId = "Red Widget"
        lineItem2.quantity = 890
        lineItem2.unitCost = 45.89F

        Dim lineItems(2) As PurchaseOrderLineItem
        lineItems(0) = lineItem1
        lineItems(1) = lineItem2
        po.orderLineItems = lineItems

        ' Submit the purchase order.
        Dim msg As New Message()
        msg.Body = po
        'Create a transaction scope.
        Using scope As New TransactionScope(TransactionScopeOption.Required)
            orderQueue.Send(msg, MessageQueueTransactionType.Automatic)
            ' Complete the transaction.
            scope.Complete()
        End Using

        Console.WriteLine("Placed the order:{0}", po)
        Console.WriteLine("Press <ENTER> to terminate client.")
        Console.ReadLine()

    End Sub

End Module
