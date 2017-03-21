    Private Sub RedoAllButDeletes()

        ' Determines if a Redo operation can be performed.
        If richTextBox1.CanRedo = True Then
            ' Determines if the redo operation deletes text.
            If richTextBox1.RedoActionName <> "Delete" Then
                ' Perform the redo.
                richTextBox1.Redo()
            End If
        End If
    End Sub