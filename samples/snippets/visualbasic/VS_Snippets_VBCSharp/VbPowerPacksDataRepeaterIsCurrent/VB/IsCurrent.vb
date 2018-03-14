Public Class IsCurrent

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub IsCurrent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_DrawItem(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs
      ) Handles DataRepeater1.DrawItem

        ' If this is the selected item.
        If e.DataRepeaterItem.IsCurrent Then
            ' ...display the PictureBox.
            e.DataRepeaterItem.Controls("SelectedPictureBox"). 
             Visible = True
        Else
            ' Otherwise, hide the PictureBox.
            e.DataRepeaterItem.Controls("SelectedPictureBox"). 
             Visible = False
        End If
    End Sub
    ' </Snippet1>
End Class
