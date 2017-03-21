        // This method handles the DropDownItemClicked event from a 
        // ToolStripDropDownItem. It displays the value of the clicked
        // item's Text property in the form's StatusStrip control.
        void toolStripDropDownItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string msg = String.Format("Item clicked: {0}", e.ClickedItem.Text);
            this.toolStripStatusLabel1.Text = msg;
        }