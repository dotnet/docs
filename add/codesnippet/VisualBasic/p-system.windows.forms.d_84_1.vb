    Private Shared Sub SetAlternateChoicesUsingItems( _
        ByVal comboboxColumn As DataGridViewComboBoxColumn)

        comboboxColumn.Items.AddRange("Mr.", "Ms.", "Mrs.", "Dr.")

    End Sub

    Private Function CreateComboBoxColumn() _
        As DataGridViewComboBoxColumn
        Dim column As New DataGridViewComboBoxColumn()

        With column
            .DataPropertyName = ColumnName.TitleOfCourtesy.ToString()
            .HeaderText = ColumnName.TitleOfCourtesy.ToString()
            .DropDownWidth = 160
            .Width = 90
            .MaxDropDownItems = 3
            .FlatStyle = FlatStyle.Flat
        End With
        Return column
    End Function