Public Class HeaderVisible

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub HeaderVisible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwndDataSet.Customers)

    End Sub
    ' <Snippet1>
    Private Sub Button1_Click() Handles Button1.Click
        ' Switch the visibility of the item header.
        If DataRepeater1.ItemHeaderVisible = True Then
            DataRepeater1.ItemHeaderVisible = False
        Else
            DataRepeater1.ItemHeaderVisible = True
        End If
    End Sub
    ' </Snippet1>
End Class
