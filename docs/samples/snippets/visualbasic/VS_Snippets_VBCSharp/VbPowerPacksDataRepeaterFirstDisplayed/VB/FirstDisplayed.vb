Public Class FirstDisplayed

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub FirstDisplayed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwndDataSet.Customers)

    End Sub
    ' <Snippet1>
    Private Sub SynchButton_Click() Handles SynchButton.Click
        ' If the first displayed item is not the current item.
        If DataRepeater1.FirstDisplayedItemIndex <> 
         DataRepeater1.CurrentItemIndex Then
            ' Make it the current item.
            DataRepeater1.CurrentItemIndex = 
              DataRepeater1.FirstDisplayedItemIndex
        End If
    End Sub
    ' </Snippet1>
End Class
