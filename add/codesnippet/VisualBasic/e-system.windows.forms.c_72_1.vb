    Private Sub ListDragTarget_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles ListDragTarget.DragDrop
        ' Ensures that the list item index is contained in the data.

        If (e.Data.GetDataPresent(GetType(System.String))) Then

            Dim item As Object = CType(e.Data.GetData(GetType(System.String)), System.Object)

            ' Perform drag-and-drop, depending upon the effect.
            If (e.Effect = DragDropEffects.Copy Or _
                e.Effect = DragDropEffects.Move) Then

                ' Insert the item.
                If (indexOfItemUnderMouseToDrop <> ListBox.NoMatches) Then
                    ListDragTarget.Items.Insert(indexOfItemUnderMouseToDrop, item)
                Else
                    ListDragTarget.Items.Add(item)

                End If
            End If
            ' Reset the label text.
            DropLocationLabel.Text = "None"
        End If
    End Sub