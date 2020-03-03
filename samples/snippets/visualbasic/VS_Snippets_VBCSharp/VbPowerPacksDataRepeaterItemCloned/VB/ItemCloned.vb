Public Class ItemCloned

    Private Sub EmployeesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmployeesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub ItemCloned_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.NorthwndDataSet.Employees)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_ItemCloned(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs
      ) Handles DataRepeater1.ItemCloned

        Dim Source As ListBox = 
            CType(DataRepeater1.ItemTemplate.Controls.Item("ListBox1"), ListBox)
        Dim ListBox1 As ListBox = 
            CType(e.DataRepeaterItem.Controls.Item("ListBox1"), ListBox)
        For Each s As String In Source.Items
            ListBox1.Items.Add(s)
        Next
    End Sub
    ' </Snippet1>
End Class
