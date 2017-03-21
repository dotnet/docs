    private void WatchRowsModeChanges(object sender,
        DataGridViewAutoSizeModeEventArgs modeEvent)
    {
        Label label =
            (Label)flowLayoutPanel1.Controls[currentLayoutName];

        if (modeEvent.PreviousModeAutoSized)
        {
            label.Text = "changed to a different " +
                label.Name +
                dataGridView1.AutoSizeRowsMode.ToString();
        }
        else
        {
            label.Text = label.Name +
                dataGridView1.AutoSizeRowsMode.ToString();
        }
    }