Public Class Form4

    '--------------------------------------------------------------------------
    Private Sub CustomersBindingNavigatorSaveItem_Click() Handles CustomersBindingNavigatorSaveItem.Click

        '<Snippet10>
        Me.Validate()
        Me.OrdersBindingSource.EndEdit()
        Me.CustomersBindingSource.EndEdit()

        Dim deletedOrders As NorthwindDataSet.OrdersDataTable = CType(
            NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Deleted), NorthwindDataSet.OrdersDataTable)

        Dim newOrders As NorthwindDataSet.OrdersDataTable = CType(
            NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Added), NorthwindDataSet.OrdersDataTable)

        Dim modifiedOrders As NorthwindDataSet.OrdersDataTable = CType(
            NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Modified), NorthwindDataSet.OrdersDataTable)


        Try
            ' Remove all deleted orders from the Orders table.
            If Not deletedOrders Is Nothing Then
                OrdersTableAdapter.Update(deletedOrders)
            End If

            ' Update the Customers table.
            CustomersTableAdapter.Update(NorthwindDataSet.Customers)

            ' Add new orders to the Orders table.
            If Not newOrders Is Nothing Then
                OrdersTableAdapter.Update(newOrders)
            End If

            ' Update all modified Orders.
            If Not modifiedOrders Is Nothing Then
                OrdersTableAdapter.Update(modifiedOrders)
            End If

            NorthwindDataSet.AcceptChanges()

        Catch ex As Exception
            MsgBox("Update failed")

        Finally
            If Not deletedOrders Is Nothing Then
                deletedOrders.Dispose()
            End If

            If Not newOrders Is Nothing Then
                newOrders.Dispose()
            End If

            If Not modifiedOrders Is Nothing Then
                modifiedOrders.Dispose()
            End If
        End Try
        '</Snippet10>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
    End Sub
End Class