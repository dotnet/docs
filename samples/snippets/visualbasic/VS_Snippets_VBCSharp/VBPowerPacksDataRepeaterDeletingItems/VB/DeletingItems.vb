Public Class DeletingItems

    Private Sub EmployeesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmployeesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.NorthwndDataSet.Employees)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_DeletingItems(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsCancelEventArgs
      ) Handles DataRepeater1.DeletingItems

        ' Check whether the user is a supervisor.
        If My.User.IsInRole("Supervisor") = False Then
            ' Cancel the deletion and display a message.
            e.Cancel = True
            MsgBox("You are not authorized to delete.")
        End If
    End Sub
    ' </Snippet1>
End Class
