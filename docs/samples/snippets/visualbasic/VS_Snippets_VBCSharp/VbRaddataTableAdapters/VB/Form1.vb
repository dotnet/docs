Public Class Form1


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        '<Snippet1>
        Dim cityValue As String = "Seattle"
        CustomersTableAdapter.FillByCity(NorthwindDataSet.Customers, cityValue)
        '</Snippet1>
    End Sub


    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.CustomersTableAdapter.Update(Me.NorthwindDataSet.Customers)
    End Sub

End Class
