    Private Sub SetUpDataGridView()

        Me.Controls.Add(dataGridView1)
        dataGridView1.ColumnCount = 5

        With dataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(dataGridView1.Font, FontStyle.Bold)
        End With

        With dataGridView1
            .EditMode = DataGridViewEditMode.EditOnEnter
            .Name = "dataGridView1"
            .Location = New Point(8, 8)
            .Size = New Size(500, 300)
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = _
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .RowHeadersVisible = False

            .Columns(0).Name = "Release Date"
            .Columns(1).Name = "Track"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Name = "Title"
            .Columns(3).Name = "Artist"
            .Columns(4).Name = "Album"

            ' Make the font italic for row four.
            .Columns(4).DefaultCellStyle.Font = _
                New Font(Control.DefaultFont, _
                    FontStyle.Italic)

            .SelectionMode = _
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .BackgroundColor = Color.Honeydew

            .Dock = DockStyle.Fill
        End With

    End Sub