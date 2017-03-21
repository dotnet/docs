        // This method handles the DropDownOpened event from a 
        // ToolStripDropDownItem. It displays the value of the 
        // item's Text property in the form's StatusStrip control.
        void toolStripDropDownItem_DropDownOpened(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = sender as ToolStripDropDownItem;

            string msg = String.Format("Item opened: {0}", item.Text);
            this.toolStripStatusLabel1.Text = msg;
        }