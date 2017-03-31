Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<Snippet8>
        OrdersTableAdapter.FillByShippedDate(NorthwindDataSet.Orders, Nothing)
        '</Snippet8>
    End Sub

    Private Sub OrdersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.OrdersBindingSource.EndEdit()
        Me.OrdersTableAdapter.Update(Me.NorthwindDataSet.Orders)
    End Sub
End Class