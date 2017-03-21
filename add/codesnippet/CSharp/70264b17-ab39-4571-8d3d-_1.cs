        // This method calls the ToolStripDropDown control's Show 
        // method to display the ContextMenuStrip relative to the
        // owning control.
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(c, e.Location, this.dropDownDirection);
            }
        }