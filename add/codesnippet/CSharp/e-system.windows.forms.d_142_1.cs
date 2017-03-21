    // Updated the criteria label.
    private void dataGridView_AutoSizeColumnModeChanged(object sender,
        DataGridViewAutoSizeColumnModeEventArgs args)
    {
        args.Column.DataGridView.Parent.
            Controls["flowlayoutpanel"].Controls[criteriaLabel].
            Text = criteriaLabel
            + args.Column.AutoSizeMode.ToString();
    }