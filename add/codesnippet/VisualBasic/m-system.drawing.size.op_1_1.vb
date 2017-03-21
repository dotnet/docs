    Private Sub subtractButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles subtractButton.Click
        subtractButton.Size = Size.op_Subtraction(subtractButton.Size, _
            New Size(10, 10))
    End Sub