        dataGridView1.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.Fill

        Dim subTitleColumn As new DataGridViewTextBoxColumn()
        subTitleColumn.HeaderText = "Subtitle"
        subTitleColumn.MinimumWidth = 50
        subTitleColumn.FillWeight = 100

        Dim summaryColumn As new DataGridViewTextBoxColumn()
        summaryColumn.HeaderText = "Summary"
        summaryColumn.MinimumWidth = 50
        summaryColumn.FillWeight = 200

        Dim contentColumn As new DataGridViewTextBoxColumn()
        contentColumn.HeaderText = "Content"
        contentColumn.MinimumWidth = 50
        contentColumn.FillWeight = 300