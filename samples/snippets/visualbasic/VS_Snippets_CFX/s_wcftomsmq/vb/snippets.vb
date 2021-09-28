Imports System.Collections.Generic
Imports System.Text
Imports System.Transactions
Imports System.ServiceModel.MsmqIntegration
Imports System.ServiceModel
Imports System.ServiceModel.Channels


Class Snippets

    Public Shared Sub Snippet2()
        ' <Snippet2>
        Dim binding As New MsmqIntegrationBinding()
        Dim address As New EndpointAddress("msmq.formatname:DIRECT=OS:.\\private$\\Orders")
        Dim channelFactory As New ChannelFactory(Of IOrderProcessor)(binding, address)
        Dim channel As IOrderProcessor = channelFactory.CreateChannel()

        Dim po As New PurchaseOrder()
        po.customerId = "somecustomer.com"
        po.poNumber = Guid.NewGuid().ToString()

        Dim lineItem1 As New PurchaseOrderLineItem()
        lineItem1.productId = "Blue Widget"
        lineItem1.quantity = 54
        lineItem1.unitCost = 29.99F

        Dim lineItem2 = New PurchaseOrderLineItem()
        lineItem2.productId = "Red Widget"
        lineItem2.quantity = 890
        lineItem2.unitCost = 45.89F

        Dim lineItems(1) As PurchaseOrderLineItem
        lineItems(0) = lineItem1
        lineItems(1) = lineItem2

        po.orderLineItems = lineItems

        Dim ordermsg As MsmqMessage(Of PurchaseOrder) = New MsmqMessage(Of PurchaseOrder)(po)
        Using scope As New TransactionScope(TransactionScopeOption.Required)
            channel.SubmitPurchaseOrder(ordermsg)
            scope.Complete()
        End Using
        Console.WriteLine("Order has been submitted:{0}", po)
        ' </Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        ' <Snippet3>
        Dim binding As New MsmqIntegrationBinding("MyBindingConfig")
        ' </Snippet3>
    End Sub

    Public Shared Sub Snippet5()
        ' <Snippet5>
        Dim binding As New MsmqIntegrationBinding(MsmqIntegrationSecurityMode.Transport)
        ' </Snippet5>
    End Sub
End Class
