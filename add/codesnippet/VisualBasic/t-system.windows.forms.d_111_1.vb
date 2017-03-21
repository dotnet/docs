    Private Sub SetBorderAndGridlineStyles()

        With Me.dataGridView1
            .GridColor = Color.BlueViolet
            .BorderStyle = BorderStyle.Fixed3D
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
        End With

    End Sub