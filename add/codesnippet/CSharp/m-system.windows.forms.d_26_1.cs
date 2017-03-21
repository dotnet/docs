    private void Form1_Load(object sender, System.EventArgs e)
    {
        // Initialize the DataGridView control.
        this.DataGridView1.ColumnCount = 5;
        this.DataGridView1.Rows.Add(new string[] { "A", "B", "C", "D", "E" });
        this.DataGridView1.Rows.Add(new string[] { "F", "G", "H", "I", "J" });
        this.DataGridView1.Rows.Add(new string[] { "K", "L", "M", "N", "O" });
        this.DataGridView1.Rows.Add(new string[] { "P", "Q", "R", "S", "T" });
        this.DataGridView1.Rows.Add(new string[] { "U", "V", "W", "X", "Y" });
        this.DataGridView1.AutoResizeColumns();
        this.DataGridView1.ClipboardCopyMode = 
            DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
    }

    private void CopyPasteButton_Click(object sender, System.EventArgs e)
    {
        if (this.DataGridView1
            .GetCellCount(DataGridViewElementStates.Selected) > 0)
        {
            try
            {
                // Add the selection to the clipboard.
                Clipboard.SetDataObject(
                    this.DataGridView1.GetClipboardContent());
                
                // Replace the text box contents with the clipboard text.
                this.TextBox1.Text = Clipboard.GetText();
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                this.TextBox1.Text = 
                    "The Clipboard could not be accessed. Please try again.";
            }
        }
    }