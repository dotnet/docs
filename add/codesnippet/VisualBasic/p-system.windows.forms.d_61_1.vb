    Private Sub ToolTips()
        Dim firstColumn As DataGridViewColumn = _
            dataGridView.Columns(0)
        Dim thirdColumn As DataGridViewColumn = _
            dataGridView.Columns(2)
        firstColumn.ToolTipText = _
            "This is column uses a default cell."
        thirdColumn.ToolTipText = _
            "This is column uses a template cell." _
            & " Changes to one cell's style changes them all."
    End Sub