Public Class CurrentItem

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub CurrentItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_CurrentItemIndexChanged(
      ) Handles DataRepeater1.CurrentItemIndexChanged

        ' Exit if the control is first loading.
        If DataRepeater1.CurrentItem Is Nothing Then Exit Sub
        ' Check for zero or negative quantity.
        If CDbl(
            DataRepeater1.CurrentItem.Controls("UnitsInStockTextBox").Text
           ) < 1 Then
            ' Display a the warning label on the form.
            Me.LowStockWarningLabel.Visible = True
        Else
            Me.LowStockWarningLabel.Visible = False
        End If
    End Sub
    ' </Snippet1>
End Class
