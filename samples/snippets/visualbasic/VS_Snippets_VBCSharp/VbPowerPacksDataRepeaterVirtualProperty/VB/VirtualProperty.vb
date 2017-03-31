Public Class VirtualProperty

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub VirtualProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)
        ' <Snippet1>
        ' If the DataRepeater is in virtual mode, 
        ' do not allow adds or deletes.
        If DataRepeater1.VirtualMode = True Then
            DataRepeater1.AllowUserToAddItems = False
            DataRepeater1.AllowUserToDeleteItems = False
            ' Disable the Add button.
            ProductsBindingNavigator.AddNewItem.Enabled = False
            ' Disable the Delete button.
            ProductsBindingNavigator.DeleteItem.Enabled = False
        End If
        ' </Snippet1>
    End Sub
End Class
