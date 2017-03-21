
        // Declare the ListView.
        private ListView ListViewWithToolTips;
        private void InitializeItemsWithToolTips()
        {

            // Construct and set the View property of the ListView.
            ListViewWithToolTips = new ListView();
            ListViewWithToolTips.Width = 200;
            ListViewWithToolTips.View = View.List;

            // Show item tooltips.
            ListViewWithToolTips.ShowItemToolTips = true;
            
            // Create items with a tooltip.
            ListViewItem item1WithToolTip = new ListViewItem("Item with a tooltip");
            item1WithToolTip.ToolTipText = "This is the item tooltip.";
            ListViewItem item2WithToolTip = new ListViewItem("Second item with a tooltip");
            item2WithToolTip.ToolTipText = "A different tooltip for this item.";

            // Create an item without a tooltip.
            ListViewItem itemWithoutToolTip = new ListViewItem("Item without tooltip.");

            // Add the items to the ListView.
            ListViewWithToolTips.Items.AddRange(new ListViewItem[]{item1WithToolTip, 
                item2WithToolTip, itemWithoutToolTip} );

            // Add the ListView to the form.
            this.Controls.Add(ListViewWithToolTips);
            this.Controls.Add(button1);
        }