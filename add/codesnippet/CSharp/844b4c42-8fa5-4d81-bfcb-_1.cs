        // This method calls the ToolStripDropDown control's Show 
        // method to display the ContextMenuStrip relative to the
        // origin of the form. 
        private void showRelativeButton_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show(this.Location, this.dropDownDirection);
        }