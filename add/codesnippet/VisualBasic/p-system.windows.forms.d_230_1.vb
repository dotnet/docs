    Private Sub CreateUnboundButtonColumn()

        ' Initialize the button column.
        Dim buttonColumn As New DataGridViewButtonColumn

        With buttonColumn
            .HeaderText = "Details"
            .Name = "Details"
            .Text = "View Details"

            ' Use the Text property for the button text for all cells rather
            ' than using each cell's value as the text for its own button.
            .UseColumnTextForButtonValue = True
        End With

        ' Add the button column to the control.
        dataGridView1.Columns.Insert(0, buttonColumn)

    End Sub