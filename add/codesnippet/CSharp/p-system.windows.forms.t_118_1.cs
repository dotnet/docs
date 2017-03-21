        // This method shows the drop-down for the first item
        // in the form's ToolStrip.
        private void showButton_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = this.toolStrip1.Items[0] as ToolStripDropDownItem;

            if (item.HasDropDownItems)
            {
                item.ShowDropDown();
            }
        }