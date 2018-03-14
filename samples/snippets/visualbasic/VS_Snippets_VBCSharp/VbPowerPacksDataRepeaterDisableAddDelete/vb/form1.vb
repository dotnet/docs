Public Class Form1

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click

    End Sub

    Private Sub BindingNavigatorDeleteItem_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.EnabledChanged
        ' <Snippet1>
        If BindingNavigatorDeleteItem.Enabled = True Then
            BindingNavigatorDeleteItem.Enabled = False
        End If
        ' </Snippet1>
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet2>
        DataRepeater1.AllowUserToAddItems = False
        DataRepeater1.AllowUserToDeleteItems = False
        BindingNavigatorAddNewItem.Enabled = False
        ordersBindingSource.AllowNew = False
        BindingNavigatorDeleteItem.Enabled = False
        ' </Snippet2>
    End Sub
End Class
