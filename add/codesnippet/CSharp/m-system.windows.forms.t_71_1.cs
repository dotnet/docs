        // This method hides the drop-down for the first item
        // in the form's ToolStrip.
        private void hideButton_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = this.toolStrip1.Items[0] as ToolStripDropDownItem;

            item.HideDropDown();
        }