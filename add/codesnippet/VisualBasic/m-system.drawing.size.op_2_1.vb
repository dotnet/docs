    Private Sub addButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles addButton.Click
        addButton.Size = Size.op_Addition(addButton.Size, New Size(10, 10))
    End Sub