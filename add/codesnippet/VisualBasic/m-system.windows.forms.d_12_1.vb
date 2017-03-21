    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles button1.Click

        ' Resize the height of the column headers. 
        dataGridView1.AutoResizeColumnHeadersHeight()

        ' Resize all the row heights to fit the contents of all 
        ' non-header cells.
        dataGridView1.AutoResizeRows( _
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)

    End Sub