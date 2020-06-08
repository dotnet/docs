'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.ServiceModel.Channels
Imports System.Configuration
'using System.Messaging;
Imports System.ServiceModel
'using System.Transactions;
Imports System.Runtime.Serialization
Imports System.Collections.Generic
Imports System.Text

Namespace Microsoft.ServiceModel.Samples
    ' Define the purchase order line item.
    <DataContract> _
    Public Class PurchaseOrderLineItem
        <DataMember> _
        Public ProductId As String

        <DataMember> _
        Public UnitCost As Single

        <DataMember> _
        Public Quantity As Integer

        Public Overrides Function ToString() As String
            Dim displayString As String = "Order LineItem: " & Quantity & " of " & ProductId & " @unit price: $" & UnitCost + Constants.vbLf
            Return displayString
        End Function

        Public ReadOnly Property TotalCost() As Single
            Get
                Return UnitCost * Quantity
            End Get
        End Property
    End Class

    ' Define the purchase order.
    <DataContract> _
    Public Class PurchaseOrder
        Private Shared ReadOnly OrderStates() As String = {"Pending", "Processed", "Shipped"}
        Private Shared statusIndexer As New Random(137)

        <DataMember> _
        Public PONumber As String

        <DataMember> _
        Public CustomerId As String

        <DataMember> _
        Public orderLineItems() As PurchaseOrderLineItem

        Public ReadOnly Property TotalCost() As Single
            Get
                Dim totalCost_Renamed As Single = 0
                For Each lineItem In orderLineItems
                    totalCost_Renamed += lineItem.TotalCost
                Next lineItem
                Return totalCost_Renamed
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return OrderStates(statusIndexer.Next(3))
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim strbuf As New StringBuilder("Purchase Order: " & PONumber & Constants.vbLf)
            strbuf.Append(Constants.vbTab & "Customer: " & CustomerId & Constants.vbLf)
            strbuf.Append(Constants.vbTab & "OrderDetails" & Constants.vbLf)

            For Each lineItem In orderLineItems
                strbuf.Append(Constants.vbTab + Constants.vbTab + lineItem.ToString())
            Next lineItem

            strbuf.Append(Constants.vbTab & "Total cost of this order: $" & TotalCost + Constants.vbLf)
            strbuf.Append(Constants.vbTab & "Order status: " & Status + Constants.vbLf)
            Return strbuf.ToString()
        End Function
    End Class

    ' Order Processing Logic
    ' Can replace with transaction-aware resource such as SQL or transacted hashtable to hold the purchase orders.
    ' This example uses a non-transactional resource.
    Public Class Orders
        Private Shared purchaseOrders As New Dictionary(Of String, PurchaseOrder)()

        Public Shared Sub Add(ByVal po As PurchaseOrder)
            purchaseOrders.Add(po.PONumber, po)
        End Sub

        Public Shared Function GetOrderStatus(ByVal poNumber As String) As String
            Dim po As PurchaseOrder = Nothing
            If purchaseOrders.TryGetValue(poNumber, po) Then
                Return po.Status
            Else
                Return Nothing
            End If
        End Function

        Public Shared Sub DeleteOrder(ByVal poNumber As String)
            If purchaseOrders(poNumber) IsNot Nothing Then
                purchaseOrders.Remove(poNumber)
            End If
        End Sub
    End Class

    ' Define a service contract. 
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface IOrderProcessor
        <OperationContract(IsOneWay:=True)> _
        Sub SubmitPurchaseOrder(ByVal po As PurchaseOrder)
    End Interface


    ' Service class that implements the service contract.
    ' Added code to write output to the console window.
    Public Class OrderProcessorService
        Implements IOrderProcessor
        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Sub SubmitPurchaseOrder(ByVal po As PurchaseOrder) Implements IOrderProcessor.SubmitPurchaseOrder
            Orders.Add(po)
            Console.WriteLine("Processing {0} ", po)
        End Sub

        ' Host the service within this EXE console application.
        Public Shared Sub Main()
            ' Get MSMQ queue name from appsettings in configuration.
            Dim queueName As String = ConfigurationManager.AppSettings("queueName")

            ' Create the transacted MSMQ queue if necessary.
            If (Not System.Messaging.MessageQueue.Exists(queueName)) Then
                System.Messaging.MessageQueue.Create(queueName, True)
            End If

            ' Get the base address that is used to listen for WS-MetaDataExchange requests.
            ' This is useful to generate a proxy for the client.
            Dim baseAddress As String = ConfigurationManager.AppSettings("baseAddress")

            ' Create a ServiceHost for the OrderProcessorService type.
            Using serviceHost As New ServiceHost(GetType(OrderProcessorService), New Uri(baseAddress))
                ' Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
            End Using
        End Sub

    End Class

End Namespace
