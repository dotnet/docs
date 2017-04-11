Public Class ItemIndex

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwndDataSet.Customers)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_DrawItem(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs
      ) Handles DataRepeater1.DrawItem

        ' Display the ItemIndex in the label.
        e.DataRepeaterItem.Controls("ItemLabel").Text = 
            CStr(e.DataRepeaterItem.ItemIndex)
    End Sub
    ' </Snippet1>
End Class
