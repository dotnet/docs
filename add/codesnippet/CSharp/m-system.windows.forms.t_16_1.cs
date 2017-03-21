        // This method handles the Click event for the button.
        // it selects the first item in the ToolStrip control
        // by using the ToolStripITem.Select method.
        private void button1_Click(object sender, EventArgs e)
        {
            RolloverItem item = this.toolStrip1.Items[0] as RolloverItem;

            if (item != null)
            {
                item.Select();

                this.Invalidate();
            }
        }