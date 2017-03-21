    Private Sub ListDragSource_GiveFeedback(ByVal sender As Object, ByVal e As GiveFeedbackEventArgs) Handles ListDragSource.GiveFeedback

        ' Use custom cursors if the check box is checked.
        If (UseCustomCursorsCheck.Checked) Then

            ' Set the custom cursor based upon the effect.
            e.UseDefaultCursors = False
            If ((e.Effect And DragDropEffects.Move) = DragDropEffects.Move) Then
                Cursor.Current = MyNormalCursor
            Else
                Cursor.Current = MyNoDropCursor
            End If
        End If

    End Sub