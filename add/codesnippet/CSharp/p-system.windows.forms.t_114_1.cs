        // This utility method creates and initializes three 
        // ToolStripDropDownItem controls and adds them 
        // to the form's ToolStrip control.
        private void InitializeToolStripDropDownItems()
        {
            ToolStripDropDownButton b = new ToolStripDropDownButton("DropDownButton");
            b.DropDown = this.contextMenuStrip1;
            b.DropDownClosed += new EventHandler(toolStripDropDownItem_DropDownClosed);
            b.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripDropDownItem_DropDownItemClicked);
            b.DropDownOpened += new EventHandler(toolStripDropDownItem_DropDownOpened);

            ToolStripMenuItem m = new ToolStripMenuItem("MenuItem");
            m.DropDown = this.contextMenuStrip1;
            m.DropDownClosed += new EventHandler(toolStripDropDownItem_DropDownClosed);
            m.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripDropDownItem_DropDownItemClicked);
            m.DropDownOpened += new EventHandler(toolStripDropDownItem_DropDownOpened);

            ToolStripSplitButton sb = new ToolStripSplitButton("SplitButton");
            sb.DropDown = this.contextMenuStrip1;
            sb.DropDownClosed += new EventHandler(toolStripDropDownItem_DropDownClosed);
            sb.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripDropDownItem_DropDownItemClicked);
            sb.DropDownOpened += new EventHandler(toolStripDropDownItem_DropDownOpened);

            this.toolStrip1.Items.AddRange(new ToolStripItem[] { b, m, sb });
        }