    Private Sub ListDragTarget_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListDragTarget.DragLeave

        ' Reset the label text.
        DropLocationLabel.Text = "None"
    End Sub