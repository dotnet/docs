Public Class AlternateBackColor

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_DrawItem(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs
      ) Handles DataRepeater1.DrawItem

        ' Alternate the back color.
        If (e.DataRepeaterItem.ItemIndex Mod 2) <> 0 Then
            ' Apply the secondary back color.
            e.DataRepeaterItem.BackColor = Color.AliceBlue
        Else
            ' Apply the default back color.
            e.DataRepeaterItem.BackColor = Color.White
        End If
        ' Change the color of out-of-stock items to red.
        If e.DataRepeaterItem.Controls(
              UnitsInStockTextBox.Name).Text < 1 Then

            e.DataRepeaterItem.Controls(UnitsInStockTextBox.Name). 
             BackColor = Color.Red
        Else
            e.DataRepeaterItem.Controls(UnitsInStockTextBox.Name). 
             BackColor = Color.White
        End If
    End Sub
    ' </Snippet1>
End Class
