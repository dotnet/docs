
Namespace LightSwitchApplication

    Public Class OrdersListDetail
        '<Snippet8>
        Private Sub RetrieveCustomer_Execute()
            Dim order As Order
            order = Me.DataWorkspace.NorthwindData.Orders_Single _
                (Orders.SelectedItem.OrderID)
            Dim cust As Customer
            cust = order.Customer
            'Perform some task on the order entity.
        End Sub
        '</Snippet8>
    End Class

End Namespace
