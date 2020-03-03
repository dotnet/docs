Public Class Form1

    Sub test()
        '<Snippet6>
        CustomersBindingSource.Filter = "CompanyName like 'B'"
        '</Snippet6>

        '<Snippet7>
        CustomersBindingSource.Sort = "CompanyName Desc"
        '</Snippet7>
    End Sub


    '<Snippet2>
    Private Sub CustomersDataGridView_DoubleClick() Handles CustomersDataGridView.DoubleClick

        Dim SelectedRowView As Data.DataRowView
        Dim SelectedRow As NorthwindDataSet.CustomersRow

        SelectedRowView = CType(CustomersBindingSource.Current, System.Data.DataRowView)
        SelectedRow = CType(SelectedRowView.Row, NorthwindDataSet.CustomersRow)

        Dim OrdersForm As New Form2
        OrdersForm.LoadOrders(SelectedRow.CustomerID)
        OrdersForm.Show()
    End Sub
    '</Snippet2>


    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.CustomersTableAdapter.Update(Me.NorthwindDataSet.Customers)
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Customers' table. You can move, or remove it, as needed.
        'Me.CustomersTableAdapter1.Fill(Me.NorthwindDataSet1.Customers)
    End Sub
End Class
