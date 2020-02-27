Public Class AllowDelete

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub AllowDelete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_AllowUserToDeleteItemsChanged(
        ) Handles DataRepeater1.AllowUserToDeleteItemsChanged

        ' If this event occurs during form initialization, exit.
        If Me.IsHandleCreated = False Then Exit Sub
        ' If AllowUserToDeleteItems is False.
        If DataRepeater1.AllowUserToDeleteItems = False Then
            ' Disable the Delete button.
            BindingNavigatorDeleteItem.Enabled = False
        Else
            ' Otherwise, enable the Delete button.
            BindingNavigatorDeleteItem.Enabled = True
        End If
    End Sub
    Private Sub BindingNavigatorDeleteItem_EnabledChanged(
        ) Handles BindingNavigatorDeleteItem.EnabledChanged

        If DataRepeater1.AllowUserToDeleteItems = False Then
            ' The BindingSource resets this property when a 
            ' new record is selected, so override it.
            If BindingNavigatorDeleteItem.Enabled = True Then
                BindingNavigatorDeleteItem.Enabled = False
            End If
        End If
    End Sub
    ' </Snippet1>

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataRepeater1.AllowUserToDeleteItems = False Then
            DataRepeater1.AllowUserToDeleteItems = True
        Else
            DataRepeater1.AllowUserToDeleteItems = False
        End If
    End Sub
End Class
