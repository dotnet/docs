'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
' <Snippet1>
' Service Code:

Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel
Imports System.Transactions
Imports System.Text
Imports System.Collections.Generic

Namespace Microsoft.ServiceModel.Samples
    ' Define a service contract. 
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples", SessionMode:=SessionMode.Required)> _
    Public Interface IOrderTaker
        <OperationContract(IsOneWay:=True)> _
        Sub OpenPurchaseOrder(ByVal customerId As String)

        <OperationContract(IsOneWay:=True)> _
        Sub AddProductLineItem(ByVal productId As String, ByVal quantity As Integer)

        <OperationContract(IsOneWay:=True)> _
        Sub EndPurchaseOrder()
    End Interface

    ' Define the Purchase Order Line Item
    Public Class PurchaseOrderLineItem
        Private Shared r As New Random(137)

        Private ProductId As String
        Private UnitCost As Single
        Private Quantity As Integer

        Public Sub New(ByVal productId As String, ByVal quantity As Integer)
            Me.ProductId = productId
            Me.Quantity = quantity
            Me.UnitCost = r.Next(10000)
        End Sub

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

    ' Define Purchase Order
    Public Class PurchaseOrder
        Private PONumber As String
        Private CustomerId As String
        Private orderLineItems As New LinkedList(Of PurchaseOrderLineItem)()

        Public Sub New(ByVal customerId As String)
            Me.CustomerId = customerId
            Me.PONumber = Guid.NewGuid().ToString()
        End Sub

        Public Sub AddProductLineItem(ByVal productId As String, ByVal quantity As Integer)
            orderLineItems.AddLast(New PurchaseOrderLineItem(productId, quantity))
        End Sub

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
                Return "Pending"
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


    ' Service class which implements the service contract.
    ' Added code to write output to the console window
    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerSession)> _
    Public Class OrderTakerService
        Implements IOrderTaker
        Private po As PurchaseOrder

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=False)> _
        Public Sub OpenPurchaseOrder(ByVal customerId As String) Implements IOrderTaker.OpenPurchaseOrder
            Console.WriteLine("Creating purchase order")
            po = New PurchaseOrder(customerId)
        End Sub

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=False)> _
        Public Sub AddProductLineItem(ByVal productId As String, ByVal quantity As Integer) Implements IOrderTaker.AddProductLineItem
            po.AddProductLineItem(productId, quantity)
            Console.WriteLine("Product " & productId & " quantity " & quantity & " added to purchase order")
        End Sub

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Sub EndPurchaseOrder() Implements IOrderTaker.EndPurchaseOrder
            Console.WriteLine("Purchase Order Completed")
            Console.WriteLine()
            Console.WriteLine(po.ToString())
        End Sub


        ' Host the service within this EXE console application.
        Public Shared Sub Main()
            ' Get MSMQ queue name from app settings in configuration
            Dim queueName As String = ConfigurationManager.AppSettings("queueName")

            ' Create the transacted MSMQ queue if necessary.
            If (Not MessageQueue.Exists(queueName)) Then
                MessageQueue.Create(queueName, True)
            End If


            ' Get the base address that is used to listen for WS-MetaDataExchange requests
            Dim baseAddress As String = ConfigurationManager.AppSettings("baseAddress")

            ' Create a ServiceHost for the OrderTakerService type.
            Using serviceHost As New ServiceHost(GetType(OrderTakerService), New Uri(baseAddress))
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
' </Snippet1>
