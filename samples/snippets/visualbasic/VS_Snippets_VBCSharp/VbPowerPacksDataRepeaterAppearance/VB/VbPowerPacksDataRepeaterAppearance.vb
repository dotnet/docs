Public Class Form1

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub

    Private Sub ProductsBindingNavigatorSaveItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub DataRepeater1_DrawItem(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs) Handles DataRepeater1.DrawItem
        ' <Snippet1>
        ' Set the default BackColor.
        e.DataRepeaterItem.BackColor = Color.White
        ' Loop through the controls on the DataRepeaterItem.
        For Each c As Control In e.DataRepeaterItem.Controls
            ' Check the type of each control.
            If TypeOf c Is TextBox Then
                ' If a TextBox, change the BackColor.
                c.BackColor = Color.AliceBlue
            Else
                ' Otherwise use the default BackColor.
                c.BackColor = e.DataRepeaterItem.BackColor
            End If
        Next
        ' </Snippet1>
    End Sub
End Class
