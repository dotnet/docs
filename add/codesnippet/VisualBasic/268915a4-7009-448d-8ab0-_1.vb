        dataGridView1.Columns.AddRange(New DataGridViewTextBoxColumn() { _
            idColumn, titleColumn, subTitleColumn, _
            summaryColumn, contentColumn})
        dataGridView1.Rows.Add(New String() {"1", _
            "A Short Title", "A Longer SubTitle", _
            "A short description of the main point.", _
            "The full contents of the topic, with detailed examples."})