        // This method handles the Closing event. The ToolStripDropDown
        // control is not allowed to close unless the Done menu item
        // is clicked or the Close method is called explicitly.
        // The Done menu item is enabled only after both of the other
        // menu items have been selected.
        private void contextMenuStrip_Closing(
            object sender, 
            ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason != ToolStripDropDownCloseReason.CloseCalled)
            {
                if (subItem1ToolStripMenuItem.Checked &&
                    subItem2ToolStripMenuItem.Checked &&
                    doneToolStripMenuItem.Enabled)
                {
                    // Reset the state of menu items.
                    subItem1ToolStripMenuItem.Checked = false;
                    subItem2ToolStripMenuItem.Checked = false;
                    doneToolStripMenuItem.Enabled = false;

                    // Allow the ToolStripDropDown to close.
                    // Don't cancel the Close operation.
                    e.Cancel = false;
                }
                else
                {
                    // Cancel the Close operation to keep the menu open.
                    e.Cancel = true;
                    this.toolStripStatusLabel1.Text = "Close canceled";
                }
            }
        }