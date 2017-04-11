'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
Imports System
Imports System.Text

' Define the purchase order line item.
<Serializable()> _
Public Class PurchaseOrderLineItem
    Public productId As String
    Public unitCost As Decimal
    Public quantity As Integer

    Public Overrides Function ToString() As String

        Dim displayString As String = "Order LineItem: " + quantity + " of " + productId + " @unit price: $" + unitCost + "\n"
        Return displayString
    End Function

    Public ReadOnly Property TotalCost() As Decimal
        Get
            Return unitCost * quantity
        End Get
    End Property
End Class

Public Enum OrderStates
    Pending
    Processed
    Shipped
End Enum

' Define the purchase order.
<Serializable()> _
Public Class PurchaseOrder

    Public poNumber As String
    Public customerId As String
    Public orderLineItems() As PurchaseOrderLineItem
    Public orderStatus As OrderStates

    Public ReadOnly Property TotalCost() As Decimal
        Get
            TotalCost = 0
            For Each lineItem As PurchaseOrderLineItem In orderLineItems
                TotalCost += lineItem.TotalCost
            Next
            Return TotalCost
        End Get
    End Property

    Public Property Status() As OrderStates
        Get
            Return orderStatus
        End Get
            set

            orderStatus = value
        End Set
    End Property

    Public Overrides Function ToString() As String

        Dim strbuf As New StringBuilder("Purchase Order: " + poNumber + "\n")
        strbuf.Append("\tCustomer: " + customerId + "\n")
        strbuf.Append("\tOrderDetails\n")

        For Each lineItem As PurchaseOrderLineItem In orderLineItems
            strbuf.Append("\t\t" + lineItem.ToString())
        Next

        strbuf.Append("\tTotal cost of this order: $" + TotalCost + "\n")
        strbuf.Append("\tOrder status: " + Status + "\n")
        Return strbuf.ToString()
    End Function
End Class

