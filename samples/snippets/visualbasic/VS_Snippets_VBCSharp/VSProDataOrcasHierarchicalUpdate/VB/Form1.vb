Public Class Form1

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        '<Snippet1>
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.OrdersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwindDataSet)
        '</Snippet1>
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'NorthwindDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
        'TODO: This line of code loads data into the 'NorthwindDataSet.Orders' table. You can move, or remove it, as needed.
        Me.OrdersTableAdapter.Fill(Me.NorthwindDataSet.Orders)
    End Sub

    Private Sub OrdersBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles OrdersBindingSource.AddingNew
        '<Snippet2>
        Me.CustomersBindingSource.EndEdit()
        '</Snippet2>
    End Sub
End Class
