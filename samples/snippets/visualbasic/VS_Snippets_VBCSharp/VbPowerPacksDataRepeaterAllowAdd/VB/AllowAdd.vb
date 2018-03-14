Public Class AllowAdd

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub AllowAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_AllowUserToAddItemsChanged(
        ) Handles DataRepeater1.AllowUserToAddItemsChanged

        ' If this event occurs during form initialization, exit.
        If Me.IsHandleCreated = False Then Exit Sub
        ' If AllowUserToAddItems is False.
        If DataRepeater1.AllowUserToAddItems = False Then
            ' Disable the Add button.
            BindingNavigatorAddNewItem.Enabled = False
            ' Disable the BindingSource property.
            ProductsBindingSource.AllowNew = False
        Else
            ' Otherwise, enable the Add button.
            BindingNavigatorAddNewItem.Enabled = True
        End If
    End Sub
    ' </Snippet1>

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataRepeater1.AllowUserToAddItems = False Then
            DataRepeater1.AllowUserToAddItems = True
        Else
            DataRepeater1.AllowUserToAddItems = False
        End If

    End Sub
End Class
