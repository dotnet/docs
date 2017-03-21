    private void AddButtonColumn()
    {
        DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
        {
            buttons.HeaderText = "Sales";
            buttons.Text = "Sales";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Honeydew;
            buttons.DisplayIndex = 0;
        }

        DataGridView1.Columns.Add(buttons);

    }