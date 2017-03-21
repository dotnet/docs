    private static void SetAlternateChoicesUsingItems(
        DataGridViewComboBoxColumn comboboxColumn)
    {
        comboboxColumn.Items.AddRange("Mr.", "Ms.", "Mrs.", "Dr.");
    }

    private DataGridViewComboBoxColumn CreateComboBoxColumn()
    {
        DataGridViewComboBoxColumn column =
            new DataGridViewComboBoxColumn();
        {
            column.DataPropertyName = ColumnName.TitleOfCourtesy.ToString();
            column.HeaderText = ColumnName.TitleOfCourtesy.ToString();
            column.DropDownWidth = 160;
            column.Width = 90;
            column.MaxDropDownItems = 3;
            column.FlatStyle = FlatStyle.Flat;
        }
        return column;
    }