        // Basic SplitContainer properties.
        // This is a vertical splitter that moves in 10-pixel increments.
        // This splitter needs no explicit Orientation property because Vertical is the default.
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.ForeColor = System.Drawing.SystemColors.Control;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // You can drag the splitter no nearer than 30 pixels from the left edge of the container.
        splitContainer1.Panel1MinSize = 30;
        // You can drag the splitter no nearer than 20 pixels from the right edge of the container.
        splitContainer1.Panel2MinSize = 20;
        splitContainer1.Size = new System.Drawing.Size(292, 273);
        splitContainer1.SplitterDistance = 79;
        // This splitter moves in 10-pixel increments.
        splitContainer1.SplitterIncrement = 10;
        splitContainer1.SplitterWidth = 6;
        // splitContainer1 is the first control in the tab order.
        splitContainer1.TabIndex = 0;
        splitContainer1.Text = "splitContainer1";
        // When the splitter moves, the cursor changes shape.
        splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(splitContainer1_SplitterMoved);
        splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(splitContainer1_SplitterMoving);

        // Add a TreeView control to the left panel.
        splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
        // Add a TreeView control to Panel1.
        splitContainer1.Panel1.Controls.Add(treeView1);
        splitContainer1.Panel1.Name = "splitterPanel1";
        // Controls placed on Panel1 support right-to-left fonts.
        splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
