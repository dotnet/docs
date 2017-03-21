        // This method explicitly closes the ToolStripDropDown control
        // and specifies the reason for closing as CloseCalled.
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Close(ToolStripDropDownCloseReason.CloseCalled);
        }