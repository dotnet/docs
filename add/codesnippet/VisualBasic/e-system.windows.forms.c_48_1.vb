    Private Sub ListDragTarget_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles ListDragTarget.DragEnter

        ' Reset the label text.
        DropLocationLabel.Text = "None"
    End Sub