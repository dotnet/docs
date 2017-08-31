Public Class CancelEdit

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub CancelEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub

    
    ' <Snippet1>
    Private Sub ProductNameTextBox_KeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.KeyEventArgs
      ) Handles ProductNameTextBox.KeyDown

        If e.KeyCode = Keys.Escape Then
            DataRepeater1.CancelEdit()
        End If
    End Sub
    ' </Snippet1>
End Class
