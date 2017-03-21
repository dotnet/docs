        dataGridView1.Columns.AddRange(new DataGridViewTextBoxColumn[] { 
            idColumn, titleColumn, subTitleColumn, 
            summaryColumn, contentColumn });
        dataGridView1.Rows.Add(new String[] { "1", 
            "A Short Title", "A Longer SubTitle", 
            "A short description of the main point.", 
            "The full contents of the topic, with detailed examples." });