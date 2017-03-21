    private DataGridView dataGridView1 = new DataGridView();

    private void AddColorColumn()
    {
        DataGridViewComboBoxColumn comboBoxColumn =
            new DataGridViewComboBoxColumn();
        comboBoxColumn.Items.AddRange(
            Color.Red, Color.Yellow, Color.Green, Color.Blue);
        comboBoxColumn.ValueType = typeof(Color);
        dataGridView1.Columns.Add(comboBoxColumn);
        dataGridView1.EditingControlShowing +=
            new DataGridViewEditingControlShowingEventHandler(
            dataGridView1_EditingControlShowing);
    }

    private void dataGridView1_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox combo = e.Control as ComboBox;
        if (combo != null)
        {
            // Remove an existing event-handler, if present, to avoid 
            // adding multiple handlers when the editing control is reused.
            combo.SelectedIndexChanged -=
                new EventHandler(ComboBox_SelectedIndexChanged);

            // Add the event handler. 
            combo.SelectedIndexChanged +=
                new EventHandler(ComboBox_SelectedIndexChanged);
        }
    }

    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((ComboBox)sender).BackColor = (Color)((ComboBox)sender).SelectedItem;
    }