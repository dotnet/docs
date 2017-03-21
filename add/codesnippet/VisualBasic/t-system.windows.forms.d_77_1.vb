    Private Sub AddOutOfOfficeColumn()
        Dim column As New DataGridViewCheckBoxColumn()
        With column
            .HeaderText = ColumnName.OutOfOffice.ToString()
            .Name = ColumnName.OutOfOffice.ToString()
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With

        DataGridView1.Columns.Insert(0, column)
    End Sub