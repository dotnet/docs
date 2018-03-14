Public Class Form2

    '<Snippet1>
    Friend Sub LoadOrders(ByVal CustomerID As String)
        OrdersTableAdapter.FillByCustomerID(NorthwindDataSet.Orders, CustomerID)
    End Sub
    '</Snippet1>


    Private Sub OrdersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.OrdersBindingSource.EndEdit()
        Me.OrdersTableAdapter.Update(Me.NorthwindDataSet.Orders)
    End Sub


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Orders' table. You can move, or remove it, as needed.
        'Me.OrdersTableAdapter.Fill(Me.NorthwindDataSet.Orders)
    End Sub

End Class