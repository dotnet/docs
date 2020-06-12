' <Snippet12>
' This is the client code.
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel
Imports System.Transactions

Namespace Microsoft.ServiceModel.Samples
    'The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    'Client implementation code.
    Friend Class Client
        Shared Sub Main()
            ' Create a client.
            Dim client As New OrderProcessorClient()

            ' Create the purchase order.
            Dim po As New PurchaseOrder()
            po.CustomerId = "somecustomer.com"
            po.PONumber = Guid.NewGuid().ToString()

            Dim lineItem1 As New PurchaseOrderLineItem()
            lineItem1.ProductId = "Blue Widget"
            lineItem1.Quantity = 54
            lineItem1.UnitCost = 29.99F

            Dim lineItem2 As New PurchaseOrderLineItem()
            lineItem2.ProductId = "Red Widget"
            lineItem2.Quantity = 890
            lineItem2.UnitCost = 45.89F

            po.orderLineItems = New PurchaseOrderLineItem(1) {}
            po.orderLineItems(0) = lineItem1
            po.orderLineItems(1) = lineItem2

            ' <Snippet8>
            'Create a transaction scope.
            Using scope As New TransactionScope(TransactionScopeOption.Required)
                ' Make a queued call to submit the purchase order.
                client.SubmitPurchaseOrder(po)
                ' Complete the transaction.
                scope.Complete()
            End Using

            'Closing the client gracefully closes the connection and cleans up resources.
            client.Close()
            ' </Snippet8>

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub
    End Class
End Namespace
' </Snippet12>
