Public Class Class1

    Sub OtherSnips()
        Dim CustomerBindingSource As New System.Windows.Forms.BindingSource()

        '<Snippet5>
        Dim currentCustomer As New Customer()
        CustomerBindingSource.Add(currentCustomer)
        '</Snippet5>

        '<Snippet6>
        Dim currentOrder As New Order()
        currentCustomer.Orders.Add(currentOrder)
        '</Snippet6>

        '<Snippet7>
        Dim customerIndex As Integer = CustomerBindingSource.Find("CustomerID", "ALFKI")
        CustomerBindingSource.RemoveAt(customerIndex)
        '</Snippet7>

    End Sub

End Class


Namespace WrapOrders

    Public Class Order
    End Class

    '<Snippet8>
    ''' <summary>
    ''' A collection of Orders
    ''' </summary>
    Public Class Orders
        Inherits System.ComponentModel.BindingList(Of Order)

        ' Add any additional functionality required by your collection.

    End Class
    '</Snippet8>
End Namespace
