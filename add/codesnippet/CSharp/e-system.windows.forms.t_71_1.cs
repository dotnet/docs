        // This method handles the DropDownClosed event from a 
        // ToolStripDropDownItem. It displays the value of the 
        // item's Text property in the form's StatusStrip control.
        void toolStripDropDownItem_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = sender as ToolStripDropDownItem;

            string msg = String.Format("Item closed: {0}", item.Text);
            this.toolStripStatusLabel1.Text = msg;
        }