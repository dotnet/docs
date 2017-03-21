#Region "data store maintance"
    Const initialValue As Integer = -1

    Private Sub dataGridView1_CellValueNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValueNeeded

        If store.ContainsKey(e.RowIndex) Then
            ' Use the store if the e value has been modified 
            ' and stored.
            e.Value = store(e.RowIndex)
        ElseIf newRowNeeded AndAlso e.RowIndex = numberOfRows Then
            If dataGridView1.IsCurrentCellInEditMode Then
                e.Value = initialValue
            Else
                ' Show a blank value if the cursor is just resting
                ' on the last row.
                e.Value = String.Empty
            End If
        Else
            e.Value = e.RowIndex
        End If
    End Sub

    Private Sub dataGridView1_CellValuePushed(ByVal sender As Object, _
        ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValuePushed

        store.Add(e.RowIndex, CInt(e.Value))

    End Sub
#End Region

    Dim store As System.Collections.Generic.Dictionary(Of Integer, Integer) = _
        New Dictionary(Of Integer, Integer)