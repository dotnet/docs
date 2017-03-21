        dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        DataGridViewTextBoxColumn subTitleColumn =
            new DataGridViewTextBoxColumn();
        subTitleColumn.HeaderText = "Subtitle";
        subTitleColumn.MinimumWidth = 50;
        subTitleColumn.FillWeight = 100;

        DataGridViewTextBoxColumn summaryColumn =
            new DataGridViewTextBoxColumn();
        summaryColumn.HeaderText = "Summary";
        summaryColumn.MinimumWidth = 50;
        summaryColumn.FillWeight = 200;

        DataGridViewTextBoxColumn contentColumn =
            new DataGridViewTextBoxColumn();
        contentColumn.HeaderText = "Content";
        contentColumn.MinimumWidth = 50;
        contentColumn.FillWeight = 300;