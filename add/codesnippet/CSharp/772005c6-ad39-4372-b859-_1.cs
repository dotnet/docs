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