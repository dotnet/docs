    ' Swap the last column with the first.
    Private Sub Button10_Click(ByVal sender As Object, _
        ByVal args As EventArgs) Handles Button10.Click

        Dim columnCollection As DataGridViewColumnCollection = _
            dataGridView.Columns

        Dim firstVisibleColumn As DataGridViewColumn = _
            columnCollection.GetFirstColumn(DataGridViewElementStates.Visible)
        Dim lastVisibleColumn As DataGridViewColumn = _
            columnCollection.GetLastColumn(DataGridViewElementStates.Visible, _
            Nothing)

        Dim firstColumn_sIndex As Integer = firstVisibleColumn.DisplayIndex
        firstVisibleColumn.DisplayIndex = _
            lastVisibleColumn.DisplayIndex
        lastVisibleColumn.DisplayIndex = firstColumn_sIndex
    End Sub