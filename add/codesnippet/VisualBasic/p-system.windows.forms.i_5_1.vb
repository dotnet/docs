    Private Sub treeView1_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs)

        ' Move the dragged node when the left mouse button is used.
        If e.Button = MouseButtons.Left Then
            DoDragDrop(e.Item, DragDropEffects.Move)

        ' Copy the dragged node when the right mouse button is used.
        ElseIf e.Button = MouseButtons.Right Then
            DoDragDrop(e.Item, DragDropEffects.Copy)
        End If
    End Sub 'treeView1_ItemDrag