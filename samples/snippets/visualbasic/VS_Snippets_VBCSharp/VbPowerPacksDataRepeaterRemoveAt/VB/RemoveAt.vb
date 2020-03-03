Public Class RemoveAt

    Private Sub EmployeesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmployeesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub RemoveAt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.NorthwndDataSet.Employees)

    End Sub
    ' <Snippet1>
    Private Sub RemoveButton_Click() Handles RemoveButton.Click
        ' Remove the second item. (Index is zero-based.)
        DataRepeater1.RemoveAt(1)
    End Sub
    ' </Snippet1>
End Class
