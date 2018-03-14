Public Class Form1

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        '<snippet2>
        Me.EndEditOnAllBindingSources()
        '</snippet2>
        Me.TableAdapterManager.UpdateAll(Me.NorthwindDataSet)

    End Sub

    '<snippet1>
    Private Sub EndEditOnAllBindingSources()
        Dim BindingSourcesQuery = From bindingsources In Me.components.Components 
                      Where (TypeOf bindingsources Is Windows.Forms.BindingSource) 
                      Select bindingsources

        For Each bindingSource As Windows.Forms.BindingSource In BindingSourcesQuery
            bindingSource.EndEdit()
        Next
    End Sub
    '</snippet1>


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Order_Details' table. You can move, or remove it, as needed.
        Me.Order_DetailsTableAdapter.Fill(Me.NorthwindDataSet.Order_Details)
        'TODO: This line of code loads data into the 'NorthwindDataSet.Orders' table. You can move, or remove it, as needed.
        Me.OrdersTableAdapter.Fill(Me.NorthwindDataSet.Orders)
        'TODO: This line of code loads data into the 'NorthwindDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)

    End Sub
End Class
