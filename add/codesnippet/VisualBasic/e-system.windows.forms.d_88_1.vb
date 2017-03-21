    Private Sub dataGridView1_RowDirtyStateNeeded(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.QuestionEventArgs) _
        Handles dataGridView1.RowDirtyStateNeeded

        If Not rowScopeCommit Then

            ' In cell-level commit scope, indicate whether the value
            ' of the current cell has been modified.
            e.Response = Me.dataGridView1.IsCurrentCellDirty

        End If

    End Sub