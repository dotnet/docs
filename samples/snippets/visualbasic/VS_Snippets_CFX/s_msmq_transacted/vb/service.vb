' <Snippet9>
' This is the service code
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel
Imports System.Transactions
Imports System.Runtime.Serialization
Imports System.Collections.Generic

Namespace Microsoft.ServiceModel.Samples
	' Define the purchase order line item.
	<DataContract(Namespace := "http://Microsoft.ServiceModel.Samples")> _
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
	' <Snippet2>
	<DataContract(Namespace := "http://Microsoft.ServiceModel.Samples")> _
	Public Class PurchaseOrder
		Private Shared ReadOnly OrderStates() As String = { "Pending", "Processed", "Shipped" }
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
			Dim strbuf As New System.Text.StringBuilder("Purchase Order: " & PONumber & Constants.vbLf)
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
	' </Snippet2>

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
	' <Snippet1>
	<ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
	Public Interface IOrderProcessor
		<OperationContract(IsOneWay := True)> _
		Sub SubmitPurchaseOrder(ByVal po As PurchaseOrder)
	End Interface
	' </Snippet1>

	' Service class that implements the service contract.
	' Added code to write output to the console window.
	' <Snippet3>
	Public Class OrderProcessorService
		Implements IOrderProcessor
		<OperationBehavior(TransactionScopeRequired := True, TransactionAutoComplete := True)> _
		Public Sub SubmitPurchaseOrder(ByVal po As PurchaseOrder) Implements IOrderProcessor.SubmitPurchaseOrder
			Orders.Add(po)
			Console.WriteLine("Processing {0} ", po)
		End Sub
	End Class
	' </Snippet3>
End Namespace
' </Snippet9>